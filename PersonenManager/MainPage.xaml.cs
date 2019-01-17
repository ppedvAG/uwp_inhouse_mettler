using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PersonenManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {

        public static ObservableCollection<Person> PersonenStatic { get; set; } = new ObservableCollection<Person>()
        {
            new Person("Max Fischer", true, "Hellene Fischer"),
            new Person("Steffi Graf", false)
        };

        public ObservableCollection<Person> Personen => PersonenStatic;

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = Personen;

            Button b1 = new Button();
            b1.FontSize = 12;
            b1.SetValue(Button.FontSizeProperty, 12);

           
            this.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(ClickCounter), true);
            

        }

        private int _clicks = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Clicks
        {
            get { return _clicks; }
            set
            {
                _clicks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Clicks)));
            }
        }


        private void ClickCounter(object sender, PointerRoutedEventArgs e)
        {
            Clicks++;
        }

        public void FügePersonHinzu()
        {
            Personen.Add(new Person());
        }

        public void LöschePerson(Person p)
        {
            Personen.Remove(p);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

       
    }
}
