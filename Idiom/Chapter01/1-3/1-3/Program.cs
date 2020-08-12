using System;

namespace _1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //演習1.3-2
            Student student = new Student
            {
                Name = "ミズタニ　タカオ",
                Birthday = new DateTime(1993, 11, 01),
                Grade = 1,
                ClassNumber = 3

            };

            //演習1.3-3
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Birthday);
            Console.WriteLine(student.Grade);
            Console.WriteLine(student.ClassNumber);


            //演習1.3-4
            Person studentP = student;
            Object studentO = student;

        }

    }
}
