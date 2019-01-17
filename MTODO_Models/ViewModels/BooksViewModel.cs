using MTODO_Models.Helper;
using MTODO_Models.Models;
using MTODO_Models.Services;
using System;
using System.Collections.ObjectModel;

namespace MTODO_Models.ViewModels
{
    public class BooksViewModel : ModelBase, IViewModel
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetValue(ref _searchTerm, value);
                SearchBookCommand.OnCanExecuteChanged();
            }
        }

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetValue(ref _books, value); }
        }

        public DelegateCommand SearchBookCommand { get; set; }
        public DelegateCommand AddBookAsTodoCommand { get; set; }


        public BooksViewModel()
        {
            SearchBookCommand = new DelegateCommand(SearchBooks, BookSearchable);
            AddBookAsTodoCommand = new DelegateCommand(AddBookAsTodo);
        }

        private void AddBookAsTodo(object obj)
        {
            if(obj is Book book)
            {
                Todo neuesTodo = new Todo();
                neuesTodo.Title = book.volumeInfo.title;
                neuesTodo.DueDate = DateTime.Now.AddDays(7);
                //TODO: Bild hinzufügen
                GUIServices.Navigation.NavigateTo(new TodosViewModel(neuesTodo));
            }
        }

        private bool BookSearchable(object arg) => !string.IsNullOrWhiteSpace(SearchTerm);

        private async void SearchBooks(object obj)
        {
            Books = new ObservableCollection<Book>(await BookSearchService.SearchBooksAsync(SearchTerm));
        }
    }
}