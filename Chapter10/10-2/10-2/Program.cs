using System;

namespace _10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new int[] { 3, -12, 23, 2 };
            
            Console.WriteLine($"マイナス値含む最小値は{Arrayutils.Getmin(arrayList)}です");


        }

    }
}
