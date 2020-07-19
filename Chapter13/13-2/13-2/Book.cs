using System;
using System.Collections.Generic;
using System.Text;

namespace _13_2
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Rating { get; }

        public Book(string title, string author, int pages, int rating)
        {
            Title = title;
            Author = author;
            Pages = pages;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"タイトル：{Title} 著者：{Author}";
        }



    }
}
