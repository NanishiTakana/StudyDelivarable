using System;
using System.Threading.Channels;

namespace AtCoderTutorial3
{
    class Program
    {
        static void Main(string[] args)
        {
            //升目の数を設定
            int massNumber = 3;
            //升目を設定
            int[] mass = new int[massNumber];
            //ビー玉が置かれる個所を数えるカウンターを設定
            int marbleCounter = 0;
            //数値の入力
            var inputNumber = Console.ReadLine();
             


            for (int n = 0; n < massNumber; n++)
            {
                //入力された数値を分割
                char SplitNumber = inputNumber[n];

                if (SplitNumber == '1')
                {
                    marbleCounter += 1;
                }
            }

            Console.WriteLine(marbleCounter);

        }
    }
}
