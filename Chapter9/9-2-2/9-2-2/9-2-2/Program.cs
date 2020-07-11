using System;

namespace _9_2_2
{
    class Program
    {
        static void Main(string[] args)
        {

            for (; ; )
            {
                Console.WriteLine("日付を入力してください");
                var inputDate = Console.ReadLine();
                DateTime date;

                //入力値が日付かどうか判定。日付型なら、DateTime型に変換し、
                //日付型でないのなら、再入力させる。
                if (DateTime.TryParse(inputDate, out date))
                {
                    Console.WriteLine($"{date.ToShortDateString()}の曜日は{date.DayOfWeek}です");
                    break;
                }
                else
                {
                    Console.WriteLine("日付型以外が入力されています。もう一度入力してください");
                }
            }

        }
    }
}
