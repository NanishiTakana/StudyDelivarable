using System;
using System.Diagnostics.Tracing;

namespace AtCoderTutorial4
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountMass = int.Parse(Console.ReadLine());
            string[] inputString = Console.ReadLine().Split(' ');
            int counter = 0;
            int[] convertInt = new int[amountMass];
            bool breakFlag = false; //処理終了フラグ

            //入力値の配列をInt型へ変換
            for (int n = 0; n < amountMass; n++)
            {
                convertInt[n] = int.Parse(inputString[n]);
            }

            for (; ; )
            {
                for (int n = 0; n < amountMass; n++)
                {

                    if (convertInt[n] % 2 == 0)
                    {
                        convertInt[n] = convertInt[n] / 2 ;
                    }
                    else
                    {
                        //奇数の場合は処理終了フラグを立てる
                        breakFlag = true;
                    }

                }

                //もし、処理終了フラグがfalseの場合、処理を終了する。
                if (breakFlag == true)
                {
                    break;
                }
                counter += 1;

            }

            Console.WriteLine(counter);

        }
    }
}
