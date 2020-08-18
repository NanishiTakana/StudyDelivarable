using System;
using System.Collections.Generic;

namespace _12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dates = new List<DateTime>()
            {
                new DateTime(2019,11,21,12,22,00),
                new DateTime(3221,12,21,13,54,44)
            };

            Console.WriteLine($"リストオブジェクトに格納されているDateTimeオブジェクトの数は{dates.Count}");
            foreach (DateTime n in dates)
            {
                Console.WriteLine(n.ToString("yyyy年mm月dd日 HH:mm"));
                
            }
 

        }
    }
}
