using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = new string[8];
            var maxString = "";
            for (int n = 0; n < inputString.Length; n++)
            {

                Console.WriteLine("{0}回目の文字列を入力してください", n + 1);
                inputString[n] = Console.ReadLine();

                //もし入力された文字列が現在の最大文字数より多い場合は、最大文字数の文字を更新する
                if (inputString[n].Length >= maxString.Length)
                {
                    maxString = inputString[n];
                }
            }

            Console.WriteLine("入力された文字の中で最大文字数の文字列は、「{0}」の{1} 文字です" , maxString ,maxString.Length);


        }
    }
}
