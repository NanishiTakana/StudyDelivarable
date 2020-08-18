using System;

namespace _15_2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {

                var total = 1000;
                var count = 0;

                Console.WriteLine("割る数を入力してください");
                var line = Console.ReadLine();
                if (int.TryParse(line, out var num))
                {
                    count = num;
                    //countが0じゃないとき割り算をする
                    if (count != 0)
                    {
                        var ans = total / count;
                        Console.WriteLine(ans);
                        Console.WriteLine("正常終了");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("0で割ることはできません。もう一度入力してください");
                    }
                }
                else
                {
                    Console.WriteLine("入力された値が正しくありません。もう一度入力してください");
                }


            }

        }
    }
}
