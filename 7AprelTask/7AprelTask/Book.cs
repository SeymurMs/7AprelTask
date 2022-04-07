using System;
using System.Collections.Generic;
using System.Text;

namespace _7AprelTask
{
    internal class Book
    {
        public Book(int id , string name , string authorName , double price)
        {
            this.AuthorName = authorName;
            this.Name = name;
            this.Price = price;
            this.Id = id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }

        public string ShowInfo()
        {
            return $"ID: {this.Id} Name: {this.Name}";
        }
    }
}
