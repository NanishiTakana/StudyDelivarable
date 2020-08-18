using System;

namespace _9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFrame = 2; //配列を入力する回数
            var number = new double[inputFrame];
            var min = 0.0;

            for (int n = 0; n < inputFrame; n++)
            {
                Console.WriteLine($"{n + 1}回目の数値を入力してください");
                number[n] = double.Parse(Console.ReadLine());
                //最初の一回目だけ、最小値を入力された値にする
                if (n == 0)
                {
                    min = number[0];
                }
                min = Math.Min(min, number[n]);
            }

            Console.WriteLine($"入力された数値の中で最も小さい数値は、{min}です");

        }
    }
}
