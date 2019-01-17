using MTODO.Views;
using MTODO_Models.Services;
using MTODO_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MTODO.Helper
{
    public class NavigationService : INavigationService
    {
        public Frame RootFrame { get; set; }

        public void NavigateTo(IViewModel model)
        {
            if(model is TodosViewModel)
            {
                RootFrame.Navigate(typeof(TodosPage), model);
            }
            else if(model is BooksViewModel)
            {
                RootFrame.Navigate(typeof(BooksPage), model);
            }
        }

        public NavigationService(Frame rootFrame)
        {
            RootFrame = rootFrame;
        }
    }
}
