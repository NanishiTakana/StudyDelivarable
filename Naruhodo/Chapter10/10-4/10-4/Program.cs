using System;
using System.Threading;

namespace _10_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("ルーンの子供達", "ジョン・ミンヒ");
            book.Print();
        }
    }
}
