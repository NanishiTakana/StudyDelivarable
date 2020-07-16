using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace _11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = "";
            var month = "";
            var day = "";
            var birthDay = "";


            for (; ; )
            {
                Console.WriteLine("生まれた年を入力してください");
                year = Console.ReadLine(); //生まれた年を入力
                Console.WriteLine("生まれた月を入力してください");
                month = Console.ReadLine();//生まれた月を入力
                Console.WriteLine("生まれた日を入力してください");
                day = Console.ReadLine();  //生まれた日を入力

                //誕生日を設定
                birthDay = year + "/" + month + "/" + day;
                Console.WriteLine(birthDay);

                if (DateTime.TryParse(birthDay , out DateTime result))
                {
                    Console.WriteLine($"あなたが生まれた日は、{result.DayOfWeek}です" );
                    break;

                }
                else
                {
                    Console.WriteLine("日付が正しく入力されていませんもう一度入力してください");
                }


            }


        }
    }
}
