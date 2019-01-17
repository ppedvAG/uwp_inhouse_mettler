using MTODO.Helper;
using MTODO_Models.Services;
using MTODO_Models.ViewModels;
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

namespace MTODO.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel Model { get; set; } = new MainViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            GUIServices.Navigation = new NavigationService(rootFrame);
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is NavigationViewItem item)
            {
                if (item.Tag.ToString() == "Book")
                {
                    Model.GoToBooksViewCommand.Execute(null);
                }
                else if (item.Tag.ToString() == "Todo")
                {
                    Model.GoToTodosViewCommand.Execute(null);
                }
            }
        }
    }
}
