using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = new int[20]; 
            var startNumber = 100; //スタート時の数字

            for (int n = 0; n < 20; n++)
            {
                score[n] = startNumber; //数字を格納
                Console.WriteLine(startNumber);
                startNumber += 1;
            }

        }
    }
}
