using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.AppService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Server
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = new AppServiceConnection())
            {
                connection.AppServiceName = "TodoService";
                connection.PackageFamilyName = "0be53fe3-fcf0-46bc-93be-74ec56fa7b3f_effe681hq0sj4";
                AppServiceConnectionStatus status = await connection.OpenAsync();

                switch (status)
                {
                    case AppServiceConnectionStatus.Success:
                        tbStatus.Items.Add("Verbindung zum Webservice hergestellt!");
                        break;

                    case AppServiceConnectionStatus.AppNotInstalled:
                        tbStatus.Items.Add("Nicht installiert!");
                        return;

                    case AppServiceConnectionStatus.AppUnavailable:
                        tbStatus.Items.Add("Nicht verfügbar!");
                        return;

                    case AppServiceConnectionStatus.AppServiceUnavailable:
                        tbStatus.Items.Add("App Service nicht verfügbar!");
                        return;
                    case AppServiceConnectionStatus.Unknown:
                        tbStatus.Items.Add("Unbekannter Fehler!");
                        return;
                }

                var inputs = new ValueSet();
                inputs.Add("title", textboxTitle.Text);
                

                inputs.Add("duedate", JsonConvert.SerializeObject(DateTime.Now.AddDays(2)));
                AppServiceResponse response = await connection.SendMessageAsync(inputs);

                if (response.Status == AppServiceResponseStatus.Success)
                {
                    tbStatus.Items.Add("Todo wurde durch App-Service erstellt!");
                    return;
                }

                switch (response.Status)
                {
                    case AppServiceResponseStatus.Failure:
                        tbStatus.Items.Add("Fehler!");
                        return;
                    case AppServiceResponseStatus.ResourceLimitsExceeded:
                        tbStatus.Items.Add("ResourceLimit überstiegen!");
                        return;
                    case AppServiceResponseStatus.Unknown:
                        tbStatus.Items.Add("Unbekannter Fehler beim Senden!");
                        return;
                }
            }
        }
    }
}
