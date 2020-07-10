using System;

namespace ConsoleApp1
{
    class Program
    {
        static class BmiCalculator
        {
            public static double GetBmi(double height, double weight)
            {
                var metersTall = height / 100.0;
                var bmi = weight / (metersTall * metersTall);
                return bmi;
            }

            public static string GetBodyType(double bmi)
            {
                var type = "";

                if (bmi < 18.5)
                {
                    type = "痩せ 型";
                }
                else if (bmi < 25)
                {
                    type = "普通 体重";
                }
                else if (bmi < 30)
                {
                    type = "肥満( 1 度)";
                }
                else if (bmi < 35)
                {
                    type = "肥満( 2 度)";
                }
                else if (bmi < 40)
                {
                    type = "肥満( 3 度)";
                }
                else
                {
                    type = "肥満( 4 度)";
                }
                return type;
            }
        }
        static void Main(string[] args)
        {
            var bmi = BmiCalculator.GetBmi(158, 45);
            var type = BmiCalculator.GetBodyType(bmi);
            Console.WriteLine($"あなたは{type}です");

        }


    }
}
