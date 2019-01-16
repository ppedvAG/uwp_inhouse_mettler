using System;
using System.Collections.Generic;
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

namespace Hello_World
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

        private void Main_Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Neuer Button erstellen mit Click-Event, danach wird Hello World angezeigt
            if(this.Content is Grid grid)
            {
                Button newButton = new Button();
                newButton.HorizontalAlignment = HorizontalAlignment.Right;
                newButton.VerticalAlignment = VerticalAlignment.Top;
                newButton.Content = "Hello World Button";
                newButton.Margin = new Thickness(10);
                newButton.Click += NewButton_Click;
          
                grid.Children.Add(newButton);
                //mainGrid.Children.Add(newButton);     

            }
        }

        private async void NewButton_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("Hello World!").ShowAsync();
        }
    }
}
