using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using InformationBooks.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace InformationBooks.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Book selectedBook;
        public Book SelectedBook 
        {
            get { return selectedBook; }
            set 
            { 
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public ObservableCollection<Book> Books { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

       
        public MainWindowViewModel()
        {
            Books = new ObservableCollection<Book>(Book.GetBooks());
            AddCommand = new DelegateCommand(AddBook);
            RemoveCommand = new DelegateCommand(RemoveBook, CanRemoveBook);
        }

        private bool CanRemoveBook(object arg)
        {
            return (arg as Book) != null;
        }

        private void RemoveBook(object obj)
        {
            Books.Remove((Book)obj);
        }

        private void AddBook(object obj)
        {
            Books.Add(new Book { Author = "Автор", Title = "Новая книга"});
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        

    }
}
