using AnotherSpase;     //演習1.1-3
using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //演習1.1-1
            Product dorayaki = new Product(98, "どら焼き", 210);
            //演習1.1-2
            Console.WriteLine($"{dorayaki.Name}の消費税額は{dorayaki.GetTax()}円です");

            //演習1.2-2
            MyClass myClass = new MyClass();
            myClass.X = 1;
            myClass.Y = 2;

            MyPoint myPoint = new MyPoint();
            myPoint.X = 3;
            myPoint.Y = 2;

            //演習1.2-3

            PointObject(myClass, myPoint);

            Console.WriteLine(myClass.X);
            Console.WriteLine(myClass.Y);
            Console.WriteLine(myPoint.X);
            Console.WriteLine(myPoint.Y);
            //演習1.2 -4
            //実行結果、2,4,3,2
            //Classは参照型、構造体は値型のためにmyPointの値は変わらなかった。

        }

        //演習1.2 -1
        public static void PointObject(MyClass myClass ,MyPoint myPoint)
        {
            myClass.X = myClass.X * 2;
            myClass.Y = myClass.Y * 2;

            myPoint.X = myPoint.X * 2;
            myPoint.Y = myPoint.Y * 2;

        }

    }
}
