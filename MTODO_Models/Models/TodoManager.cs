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
            Todos = new ObservableCollection<Todo>();
            //TODO: Aus dem Speicher laden
        }
    }
}
