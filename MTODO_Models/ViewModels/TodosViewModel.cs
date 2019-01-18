using MTODO_Models.Helper;
using MTODO_Models.Models;
using MTODO_Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace MTODO_Models.ViewModels
{
    public class TodosViewModel : ModelBase, IViewModel
    {
        private ObservableCollection<Todo> _todoListe;
        public ObservableCollection<Todo> TodoListe
        {
            get { return _todoListe; }
            set { SetValue(ref _todoListe, value);
                ExportTodosCommand?.OnCanExecuteChanged();
            }
        }

        private Todo _currentTodo;
        public Todo CurrentTodo
        {
            get { return _currentTodo; }
            set
            {
                SetValue(ref _currentTodo, value);
                //Speichere Daten
                GUIServices.SaveService.SaveTodos(TodoListe);
                ExportTodosCommand?.OnCanExecuteChanged();
            }
        }

        public DelegateCommand ExportTodosCommand { get; set; }
        public DelegateCommand ImportTodosCommand { get; set; }
        public DelegateCommand AddTodoCommand { get; set; }

        public TodosViewModel()
        {
            TodoListe = TodoManager.Todos;
            ExportTodosCommand = new DelegateCommand(ExportTodos, p => TodoListe.Count > 0);
            ImportTodosCommand = new DelegateCommand(ImportTodos);
            AddTodoCommand = new DelegateCommand(AddTodo);
        }

        private async void ImportTodos(object obj)
        {
            var todos = await GUIServices.SaveService.ImportTodos();
            TodoListe = new ObservableCollection<Todo>(todos);
        }

        private async void ExportTodos(object obj)
        {
            await GUIServices.SaveService.ExportTodos(TodoListe);
        }

        public TodosViewModel(Todo neuesTodo) : this()
        {
            TodoListe.Add(neuesTodo);
            CurrentTodo = neuesTodo;
        }

        public TodosViewModel(int todoId) : this()
        {
            Todo zuTodo = TodoListe.FirstOrDefault(todo => todo.ID == todoId);
            if(zuTodo != null)
            {
                CurrentTodo = zuTodo;
            }
        }

        public void AddTodo(object p)
        {
            TodoListe.Add(new Todo());
        }
    }
}
