using System;
using System.Collections.Generic;
using System.Text;

namespace _7AprelTask
{
    internal class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> books { get; set; } = new List<Book>();
        
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("Xeta!");

           Book book = books.Find(x => x.Id == id);
            if (book == null)
                throw new ArgumentNullException("Xeta!");
            return book;            
        }
        public  void RemoveBook(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("Xeta!");
            Book book = books.Find(x => x.Id == id);
            if (book == null)
                throw new ArgumentNullException("Xeta!");
            books.Remove(book);
        }
    }
}
