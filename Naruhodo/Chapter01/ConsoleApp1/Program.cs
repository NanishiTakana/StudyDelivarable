using AnotherSpase;     //演習1.1-3
using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //演習1.1-2
            Product dorayaki = new Product(98, "どら焼き", 210);
            //演習1.2-2
            Console.WriteLine($"{dorayaki.Name}の消費税額は{dorayaki.GetTax()}円です");

            //演習1.2-2
            MyClass myClass = new MyClass();
            myClass.X = 1;

            MyPoint myPoint = new MyPoint();
            myPoint.Y = 2;
            
            PointObject(myClass, myPoint);

        }

        //演習1.2 -1
        public static void PointObject(MyClass myClass ,MyPoint myPoint)
        {
            Console.WriteLine(myClass.X);
            Console.WriteLine(myPoint.Y);
        }

    }
}
