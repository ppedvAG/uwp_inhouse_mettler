using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public sealed partial class CityWetter : UserControl, INotifyPropertyChanged
    {

        public string Stadt
        {
            get { return (string)GetValue(StadtProperty); }
            set { SetValue(StadtProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stadt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StadtProperty =
            DependencyProperty.Register("Stadt", typeof(string), typeof(CityWetter), new PropertyMetadata(null, StadtChanged));

        private static void StadtChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CityWetter cityWetter)
            {
                if (!string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                {
                    cityWetter.LadeWetter();
                }
            }
        }

        private string _error = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Error)));
            }
        }

        private int _temp;
        public int Temperatur
        {
            get { return _temp; }
            set
            {
                _temp = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperatur)));
            }
        }

        private string _beschreibung;
        public string Beschreibung
        {
            get { return _beschreibung; }
            set
            {
                _beschreibung = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Beschreibung)));
            }
        }

        private string  _iconUrl;
        public string IconUrl
        {
            get { return _iconUrl; }
            set
            {
                _iconUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconUrl)));
            }
        }

        public async void LadeWetter()
        {
            try
            {
                HttpClient client = new HttpClient();
                string jsonResult = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={Stadt}&units=metric&appid=84d84c7b399d88e7f4e4688facc2498e");
                var apiresult = JsonConvert.DeserializeObject<WetterAPIResult>(jsonResult);
                Temperatur = apiresult.main.temp_min;
                IconUrl = apiresult.weather[0].IconUrl;
                Beschreibung = apiresult.weather[0].description;
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
