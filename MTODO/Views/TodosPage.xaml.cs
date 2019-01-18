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
    public sealed partial class TodosPage : Page
    {
        public TodosViewModel Model { get; set; }

        public TodosPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Model = e.Parameter as TodosViewModel;
            base.OnNavigatedTo(e);
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (e.NewSize.Width > 500)
            //{
            //    masterdetailview.ItemTemplate = this.Resources["smallTemplate"]
            //}
        }
    }
}
