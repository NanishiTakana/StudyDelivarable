using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = new int[8];
            var total = 0;
            var average = 0;

            for (int n = 0; n < score.Length; n++)
            {
                Console.WriteLine("{0}回目の数字を入力してください",n + 1);
                score[n] = int.Parse(Console.ReadLine());
                total += score[n];
            }

            average = total / score.Length;
            Console.WriteLine("入力された文字の平均値は{0}です", average);


        }
    }
}
