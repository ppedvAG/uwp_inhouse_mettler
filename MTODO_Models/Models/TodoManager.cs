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
            Todos = new ObservableCollection<Todo>()
            {
                new Todo() { Title="Test",  DueDate = DateTime.Now.AddDays(1)}
            };
            //TODO: Aus dem Speicher laden
        }
    }
}
