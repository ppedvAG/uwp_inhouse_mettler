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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WerkzeugManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {

        private Werkzeug _zuEditierendesWerkzeug;

        public EditPage()
        {
            this.InitializeComponent();
            cbGewindeart.ItemsSource = Enum.GetValues(typeof(Werkzeug.Gewindegrößen));
            cbGewindeart.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = textName.Text;
            int anzahl = (int)sliderAnz.Value;
            bool ausMetall = toggleMetall.IsOn;
            Werkzeug.Gewindegrößen gewinde = (Werkzeug.Gewindegrößen)cbGewindeart.SelectedItem;

            if(_zuEditierendesWerkzeug != null)
            {
                _zuEditierendesWerkzeug.Name = name;
                _zuEditierendesWerkzeug.Anzahl = anzahl;
                _zuEditierendesWerkzeug.AusMetall = ausMetall;
                _zuEditierendesWerkzeug.Gewindegröße = gewinde;
                this.Frame.Navigate(typeof(ListPage));
            }
            else
            {
                this.Frame.Navigate(typeof(ListPage), new Werkzeug(name, ausMetall, anzahl, gewinde));
            }
        }

        //von einer anderen Page zu dieser Page navigiert
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainPage.UpdateBackButton();

            if(e.Parameter is Werkzeug werkzeug)
            {
                _zuEditierendesWerkzeug = werkzeug;
                textName.Text = werkzeug.Name;
                sliderAnz.Value = werkzeug.Anzahl;
                toggleMetall.IsOn = werkzeug.AusMetall;
                cbGewindeart.SelectedItem = werkzeug.Gewindegröße;
                button.Content = "Speichern";
            }
            base.OnNavigatedTo(e);
        }
    }
}