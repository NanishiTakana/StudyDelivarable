using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emploee1 = new Employee
            {
                Id = 1,
                FamilyName = "正山" ,
                GivenName = "周那",
                EmailAddress = "email.com"               

            };

            Employee emploee2 = new Employee
            {
                Id = 2,
                FamilyName = "宮本",
                GivenName = "むさし",
                EmailAddress = "email.com"

            };

            //フルネームの表示
            Console.WriteLine(emploee1.GetFullName());
            Console.WriteLine(emploee2.GetFullName());
            
        }

        //従業員クラス
        class Employee
        {
            public int Id { get; set; }
            public string FamilyName { get; set; }
            public string GivenName  { get; set; }
            public string EmailAddress { get; set; }

            public string GetFullName()
            {
               return FamilyName + GivenName;
            }


        }


    }
}
