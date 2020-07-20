using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InformationBooks.Model
{
    class Book : INotifyPropertyChanged
    {
		int aaaaaa = 0;
        public event PropertyChangedEventHandler PropertyChanged;

        private string author;
        private string title;

        public string Author
        {
            get { return author; }
            set 
            { 
                author = value;
                OnPropertyChanged(Author);
            }   
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(Title);
            }
        }
        public static Book[] GetBooks()
        {
            var result = new[]
            {
                new Book() { Author = "Лев Толстой", Title = "Война и мир" },
                new Book() { Author = "Чак Паланик", Title = "Призраки" },
                new Book() { Author = "Михаил Булгаков", Title = "Мастер и маргарита" }
            };
            return result;
        }

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
