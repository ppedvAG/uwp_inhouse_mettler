using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WetterApp
{
    public sealed partial class CityWetter : UserControl
    {

        public string Stadt
        {
            get { return (string)GetValue(StadtProperty); }
            set { SetValue(StadtProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stadt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StadtProperty =
            DependencyProperty.Register("Stadt", typeof(string), typeof(CityWetter), new PropertyMetadata(null,StadtChanged));

        private static void StadtChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is CityWetter cityWetter)
            {
                if(!string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    cityWetter.LadeWetter();
                }
            }
        }

        private string _error = string.Empty;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }



        public async void LadeWetter()
        {
            try
            {
                HttpClient client = new HttpClient();
                string jsonResult = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={Stadt}&units=metric&appid=84d84c7b399d88e7f4e4688facc2498e");

            }
            catch (Exception)
            {
                Error = "Das Wetter für diese Stadt konnte nicht ermittelt werden!";
            }
        }

        public CityWetter()
        {
            this.InitializeComponent();
        }
    }
}
