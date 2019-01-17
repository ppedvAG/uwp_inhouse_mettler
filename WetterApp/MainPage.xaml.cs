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

namespace WetterApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _neueStadt;

        public ObservableCollection<string> Staedte { get; set; } = new ObservableCollection<string>();

        public string NeueStadt
        {
            get => _neueStadt; set  {
                _neueStadt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeueStadt)));
            }
        }


        public MainPage()
        {
            this.InitializeComponent();
            //notwendig für normales Binding (nicht x:Bind)
            this.DataContext = Staedte;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Staedte.Add(NeueStadt);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is string stadt)
            {
                Staedte.Remove(stadt);
            }
        }
    }
}
