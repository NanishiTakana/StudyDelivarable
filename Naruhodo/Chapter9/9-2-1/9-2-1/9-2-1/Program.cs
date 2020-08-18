
using System;

namespace _9_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //課題9-2-1　2020年2月の日数の表示
            var date = DateTime.DaysInMonth(2020, 2);
            Console.WriteLine($"2020年2月の日数は{date}日です");
                 
        }
    }
}
