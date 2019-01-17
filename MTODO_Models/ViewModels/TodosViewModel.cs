using MTODO_Models.Helper;
using MTODO_Models.Models;
using MTODO_Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MTODO_Models.ViewModels
{
    public class TodosViewModel : ModelBase, IViewModel
    {
        private ObservableCollection<Todo> _todoListe;
        public ObservableCollection<Todo> TodoListe
        {
            get { return _todoListe; }
            set { SetValue(ref _todoListe, value); }
        }

        private Todo _currentTodo;
        public Todo CurrentTodo
        {
            get { return _currentTodo; }
            set { SetValue(ref _currentTodo, value); }
        }

        public TodosViewModel()
        {
            TodoListe = TodoManager.Todos;
        }

        public void AddTodo()
        {
            TodoListe.Add(new Todo());
        }
    }
}
