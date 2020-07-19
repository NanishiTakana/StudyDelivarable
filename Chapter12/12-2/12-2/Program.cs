using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _12_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>();
            books.Add(new Book(" 人間失格", "太宰治", 212, 5));
            books.Add(new Book(" 吾輩 は 猫 で ある", "夏目漱石", 610, 4));
            books.Add(new Book(" 女生徒", "太宰治", 279, 4));
            books.Add(new Book(" 銀河 鉄道 の 夜", "宮沢賢治", 357, 3));
            books.Add(new Book(" 伊豆 の 踊子", "川端康成", 201, 3));
            books.Add(new Book(" こ ゝ ろ", "夏目漱石", 378, 5));

            Console.WriteLine("\n---------------課題12-2-1----------------------\n");
            //12-2-1評価4以上の作品を判別
            Console.WriteLine($"評価4以上の作品は、");
            foreach (var book in books.Where(x => x.Rating >= 4))
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine($"です。");

            //12-2-2著者順に並び変え
            Console.WriteLine("\n---------------課題12-2-2----------------------\n");
            Console.WriteLine("著者名順に並び替えたときの書籍名の並び順は以下の通りです。");
            foreach (var book in books.OrderBy(x => x.Author))
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("著者名順に並び替えたときの著者名の並び順は以下の通りです。");
            foreach (var book in books.OrderBy(x => x.Author))
            {
                Console.WriteLine(book.Author);
            }
            //12-2-3
            Console.WriteLine("\n---------------課題12-2-3----------------------\n");
            var _300OverPagesBooks = books.Where(x => x.Pages >= 300).ToArray();
            foreach (var book in _300OverPagesBooks)
            {
                Console.WriteLine($"{book.Title}{ book.Pages}");
            }

            Console.WriteLine("\n---------------課題12-2-4----------------------\n");
            var maxPagesBook = books.OrderBy(x => x.Pages).ToArray();
            Console.WriteLine($"ページ数がもっとも多い作品のタイトルは「{maxPagesBook[0].Title}」で、ページ数は{maxPagesBook[0].Pages}ページです");
                


        }




    }
}
