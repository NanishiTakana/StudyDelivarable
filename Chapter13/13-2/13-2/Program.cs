using System;

namespace _13_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Book型のインスタンスを生成
            var book = new Book("バガボンド","井上　雄彦",154,4);
            //生成したbookインスタンスを、オブジェク型の変数を格納
            object objecrTest = book;

            Console.WriteLine(objecrTest);




        }
    }
}
