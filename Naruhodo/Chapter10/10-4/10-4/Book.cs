using System;
using System.Collections.Generic;
using System.Text;

namespace _10_4
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Rating { get; set; }
        
        public Book(string title , string author)
        {
            Title = title;
            Author = author;
            Pages = 100;
            Rating = 3;

        }

        public void Print()
        {
            Console.WriteLine($"■{this.Title}");
            Console.WriteLine($"    {this.Author} {this.Pages}ページ 評価：{this.Rating}");
        }




    }

}
