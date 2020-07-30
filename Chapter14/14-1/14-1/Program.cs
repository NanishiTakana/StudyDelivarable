using System;
using System.Collections.Generic;

namespace _14_1
{
    class Program
    {

        static void Main(string[] args)
        {
            // Q3-1
            object person = new Person
            {
                FirstName = "翔太",
                LastName = "青木",
            };
            object employee = new Employee
            {
                Number = 801,
                FirstName = "凉子",
                LastName = "高橋",
                HireDate = new DateTime(2015, 4, 1)
            };

            var str1 = person.ToString();
            Console.WriteLine(str1);
            var str2 = employee.ToString();
            Console.WriteLine(str2);

            // Q3-2
            Console.WriteLine(person);
            Console.WriteLine(employee);
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return LastName + FirstName; }
        }
    }

    // 従業員クラス
    class Employee : Person
    {
        // 従業員番号
        public int Number { get; set; }
        // 入社年月日
        public DateTime HireDate { get; set; }

        public override string ToString()
        {
            var s = $"{Number} {FullName} " +
                    $"{HireDate.Year}年{HireDate.Month}月{HireDate.Day}日入社";
            return s;
        }
    }


}