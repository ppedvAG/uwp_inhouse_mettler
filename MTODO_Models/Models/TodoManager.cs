using MTODO_Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MTODO_Models.Models
{
    public static class TodoManager
    {
        public static ObservableCollection<Todo> Todos { get; set; }

        static TodoManager()
        {
            //TODO: Aus dem Speicher laden
            var todos = GUIServices.SaveService.LoadTodos();
            if (todos != null)
            {
                Todos = new ObservableCollection<Todo>(todos);
            }
            else
            {
                Todos = new ObservableCollection<Todo>()
                {
                    new Todo() { Title="Test",  DueDate = DateTime.Now.AddDays(1)}
                };
            }
        }
    }
}
