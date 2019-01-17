using System;
using System.Collections.Generic;
using System.Text;

namespace MTODO_Models.Services
{
    public static class GUIServices
    {
        public static INavigationService Navigation { get; set; }
    }

    public interface INavigationService
    {
        void NavigateTo(IViewModel model);
    }

    public interface IViewModel
    {

    }
}
