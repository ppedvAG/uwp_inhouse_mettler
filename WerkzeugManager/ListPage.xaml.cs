using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WerkzeugManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {

        public static ObservableCollection<Werkzeug> Werkzeuge = new ObservableCollection<Werkzeug>()
        {
            new Werkzeug("Hammer", false, 2, Werkzeug.Gewindegrößen.m12),
            new Werkzeug("Nagel", true, 1, Werkzeug.Gewindegrößen.m18)
        };

        public ListPage()
        {
            this.InitializeComponent();

            lbWerkzeuge.ItemsSource = Werkzeuge;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainPage.UpdateBackButton();

            if(e.Parameter is Werkzeug werkzeug)
            {
                Werkzeuge.Add(werkzeug);
            }
            base.OnNavigatedTo(e);
        }

        private void LbWerkzeuge_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditPage), lbWerkzeuge.SelectedItem);
        }
    }
}