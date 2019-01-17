using MTODO_Models.Helper;
using MTODO_Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTODO_Models.ViewModels
{
    public class MainViewModel : ModelBase, IViewModel
    {

        public DelegateCommand GoToTodosViewCommand { get; set; }
        public DelegateCommand GoToBooksViewCommand { get; set; }

        public MainViewModel()
        {
            GoToTodosViewCommand = new DelegateCommand(p => GoToTodosView());
            GoToBooksViewCommand = new DelegateCommand(p => GoToBooksView());
        }

        public void GoToTodosView()
        {
            //TODO:
            
        }
       
        public void GoToBooksView()
        {

        }
    }
}
