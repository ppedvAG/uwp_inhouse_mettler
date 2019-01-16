using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Lokalisierung
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Resources["pageFontSize"] = 50;
        }

        private void Change_Language_Click(object sender, RoutedEventArgs e)
        {
            //welche Sprache?
            if(sender is MenuFlyoutItem item)
            {
                string dateiname = item.Tag.ToString();
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"ms-appx:///Sprachen/{dateiname}");
                this.Frame.Navigate(typeof(MainPage));
                //TODO: letzten Eintrag aus History entfernen
                //this.Frame.GetNavigationState()[]
                
            }
        }

        private void Hell_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Light;
        }

        private void Dunkel_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Dark;
        }
    }
}
