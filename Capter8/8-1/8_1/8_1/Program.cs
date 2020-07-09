using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new int[5];

            for(int n = 0; n < 5; n++)
            {
                Console.WriteLine($"{n + 1}回目の文字を入力してください");
                number[n] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine($"最大値：{ArrayUtils.Max(number)}");
            Console.WriteLine($"最小値：{ArrayUtils.Min(number)}");
        }
    }

    static class ArrayUtils
    {
        // 配列内の数値の最大値を求める 

       public static int Max(int[] numbers)
        {
            var max = 0;
            foreach(var n in numbers)
            {
                if ( n > max)
                {
                    max = n;
                }
                
            }
            return max;
        }

        //配列内の数値の最小値を求める
        public static int Min(int[] numbers)
        {
            var min = numbers[0];
            foreach (var n in numbers)
            {
                if (n < min)
                {
                    min = n;
                }

            }
            return min;
        }





    }

}
