using System;
using System.Collections.Generic;
using System.Text;

namespace MTODO_Models.Models
{
    public class BookAPIResult
    {
        public Book[] items { get; set; }
    }

    public class Book
    {
        public Volumeinfo volumeInfo { get; set; }   
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public Imagelinks imageLinks { get; set; }
    }

    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
    }
}
