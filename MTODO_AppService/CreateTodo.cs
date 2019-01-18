using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.Storage;
using MTODO_Models;
using MTODO_Models.Models;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;

namespace MTODO_AppService
{
    public class CreateTodo : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        AppServiceConnection appServiceconnection;

        public const string Todos_Settings_Key = "MyTodos";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();

            taskInstance.Canceled += OnTaskCanceled;

            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            appServiceconnection = details.AppServiceConnection;

            appServiceconnection.RequestReceived += OnRequestReceived;
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (_deferral != null)
            {
                _deferral.Complete();
                _deferral = null;
            }

            if (appServiceconnection != null)
            {
                appServiceconnection.Dispose();
                appServiceconnection = null;
            }
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var _messageDeferal = args.GetDeferral();

            ValueSet messageFromCaller = args.Request.Message;

            string title = messageFromCaller["title"] as string;
            DateTime duedate = JsonConvert.DeserializeObject<DateTime>(messageFromCaller["duedate"].ToString());

            if (ApplicationData.Current.LocalSettings.Values.TryGetValue(Todos_Settings_Key, out object result))
            {
                try
                {
                    string json = result.ToString();
                    var liste = JsonConvert.DeserializeObject<IEnumerable<Todo>>(json);

                    Todo newTodo = new Todo();
                    newTodo.Title = title;
                    newTodo.DueDate = duedate;
                    liste = liste.Append(newTodo);

                    json = JsonConvert.SerializeObject(liste);
                    ApplicationData.Current.LocalSettings.Values[Todos_Settings_Key] = json;

                    var content = new ToastContent()
                    {
                        // More about the Launch property at https://docs.microsoft.com/dotnet/api/microsoft.toolkit.uwp.notifications.toastcontent
                        Launch = "ToastContentActivationParams",

                        Visual = new ToastVisual()
                        {
                            BindingGeneric = new ToastBindingGeneric()
                            {
                                Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "TODO wurde erstellt!"
                            },

                            new AdaptiveText()
                            {
                                 Text = $"{newTodo.Title}: {newTodo.DueDate}"
                            }
                        }
                            }
                        },

                        Actions = new ToastActionsCustom()
                        {
                            Buttons =
                            {
                                // More about Toast Buttons at https://docs.microsoft.com/dotnet/api/microsoft.toolkit.uwp.notifications.toastbutton
                                new ToastButton("Anzeigen", newTodo.ID.ToString())
                                {
                                    ActivationType = ToastActivationType.Foreground
                                },

                                new ToastButtonDismiss("Abbrechen")
                            }
                        }
                    };

                    var toast = new ToastNotification(content.GetXml());
                    ToastNotificationManager.CreateToastNotifier().Show(toast);

                    ValueSet response = new ValueSet();
                    response.Add("Status", "Success");

                    await args.Request.SendResponseAsync(response);


                    ValueSet response2 = new ValueSet();
                    response2.Add("Status", "No List Found");
                    await args.Request.SendResponseAsync(response2);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _messageDeferal.Complete();
                }
            }
        }
    }
}
