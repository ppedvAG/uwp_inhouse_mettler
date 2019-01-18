using MTODO_Models.Models;
using MTODO_Models.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;

namespace MTODO.Helper
{
    public class FileService : ISaveService
    {

        public const string Todos_Settings_Key = "MyTodos";
        public const string Todos_Export_File = "Todos_Export";
        public const string Todos_Export_Folder = "Todos_Export_Folder";

        public async Task<bool> ExportTodos(IEnumerable<Todo> todos)
        {
            try
            {
                #region File direkt auswählen

                //FileSavePicker picker = new FileSavePicker();
                //picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                //picker.SuggestedFileName = "myTodos.tds";
                //picker.DefaultFileExtension = ".tds";
                //picker.FileTypeChoices.Add("Todo Files", new List<string>() { ".tds" });
                //picker.FileTypeChoices.Add("All", new List<string>() { ".*" });
                //StorageFile file = await picker.PickSaveFileAsync();
                //var stream = await file.OpenStreamForWriteAsync();
                //using (StreamWriter writer = new StreamWriter(stream))
                //{
                //    string json = JsonConvert.SerializeObject(todos);
                //    await writer.WriteAsync(json);
                //    //writer.Close();
                //}
                //StorageApplicationPermissions.FutureAccessList.Add(file, Todos_Export_File);
                #endregion

                #region Ordner auswählen
                FolderPicker picker = new FolderPicker();
                picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add("*");
                picker.ViewMode = PickerViewMode.Thumbnail;
                var folder =  await picker.PickSingleFolderAsync();
                StorageApplicationPermissions.FutureAccessList.Add(folder, Todos_Export_Folder);
                var subfolder = await folder.CreateFolderAsync("Unsere Todos");
                var file = await  subfolder.CreateFileAsync("myTodos.tds");
                var stream = await file.OpenStreamForWriteAsync();
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string json = JsonConvert.SerializeObject(todos);
                    await writer.WriteAsync(json);
                    //writer.Close();
                }

                #endregion
            }
            catch (Exception exp)
            { 
                return false;
            }
            return true;           
        }

        public async Task<IEnumerable<Todo>> ImportTodos()
        {
            foreach (var item in StorageApplicationPermissions.FutureAccessList.Entries)
            {
                if(item.Metadata == Todos_Export_File)
                {
                   StorageFile exportFile = await  StorageApplicationPermissions.FutureAccessList.GetFileAsync(item.Token);
                    var stream = await exportFile.OpenStreamForReadAsync();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        IEnumerable<Todo> todos = JsonConvert.DeserializeObject<IEnumerable<Todo>>(json);
                        return todos;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Todo> LoadTodos()
        {
            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(Todos_Settings_Key, out object value))
            {
                try
                {
                    var values = JsonConvert.DeserializeObject<IEnumerable<Todo>>(value.ToString());
                    return values;
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return null;
        }

        public bool SaveTodos(IEnumerable<Todo> todos)
        {
            try
            {
                string json = JsonConvert.SerializeObject(todos);

                //if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Todos_Settings_Key))
                //{
                ApplicationData.Current.LocalSettings.Values[Todos_Settings_Key] = json;
                //}
                //else
                //{
                //    ApplicationData.Current.LocalSettings.Values.Add(Todos_Settings_Key, json);
                //}
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
