using MTODO_Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTODO_Models.Services
{
    public static class GUIServices
    {
        public static INavigationService Navigation { get; set; }
        public static ISaveService SaveService { get; set; }
    
    }

    public interface INavigationService
    {
        void NavigateTo(IViewModel model);
    }

    public interface IViewModel
    {

    }

    public interface ISaveService
    {
        bool SaveTodos(IEnumerable<Todo> todos);
        IEnumerable<Todo> LoadTodos();
        Task<bool> ExportTodos(IEnumerable<Todo> todos);
        Task<IEnumerable<Todo>> ImportTodos();
    }
}
