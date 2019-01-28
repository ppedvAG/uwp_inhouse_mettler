using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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

        public ObservableCollection<Stadt> Staedte { get; set; } = new ObservableCollection<Stadt>();

        private string _neueStadt;
        public string NeueStadt
        {
            get => _neueStadt; set
            {
                _neueStadt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NeueStadt)));
            }
        }


        public MainPage()
        {
            this.InitializeComponent();
            //notwendig für normales Binding (nicht x:Bind)
            this.DataContext = this;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Staedte.Add(new Stadt() { Name = NeueStadt });
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Stadt stadt)
            {
                Staedte.Remove(stadt);
            }
        }

        public ObservableCollection<string> words { get; set; } = new ObservableCollection<string>() { "sadasd", "adasd" };

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            words[0] = "andere Stadt";
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string firstWord = words[0];
            await new MessageDialog(firstWord).ShowAsync();
        }
    }

    public class Stadt : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name; set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}