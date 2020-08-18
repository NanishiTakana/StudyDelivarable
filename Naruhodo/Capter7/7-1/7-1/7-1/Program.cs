using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book
            {
                Title = "吾輩 は 猫 で ある",
                Author = "夏目漱石",
                Pages = 610,
                Rating = 4,
                Memo = "書き出しが面白い"
            };

            book.print();
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Pages { get; set; }
            public int Rating { get; set; }
            public string Memo { get; set; }

            public void print()
            {
                Console.WriteLine($"タイトル：{Title}");
                Console.WriteLine($"著者：{Author}");
                Console.WriteLine($"ページ数：{Pages}");
                Console.WriteLine($"評価：{Rating}");
                Console.WriteLine($"メモ：{Memo}");
            }

        }

    }
}
