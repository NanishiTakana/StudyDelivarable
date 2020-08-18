using System;

namespace _9_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNum = "";
            var number = 0.0;
            var numFloor = 0.0;
            var numCeiling = 0.0;

            for (;;)
            {
                Console.WriteLine("数値を入力してください");
                inputNum = Console.ReadLine();
                
                //空の行を入力したとき、処理を終える。
                if(inputNum == "")
                {
                    Console.WriteLine("処理を終了します");
                    break;
                }
                number = double.Parse(inputNum);

                numFloor = Math.Floor(number) ;
                numCeiling = Math.Ceiling(number);

                Console.WriteLine($"入力された数値を小数点切り捨てした数値は、{numFloor}で");
                Console.WriteLine($"入力された数値を小数点切り上げした数値は、{numCeiling}です。");

            }

        }
    }
}
