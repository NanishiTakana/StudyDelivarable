using System;
using System.Collections.Generic;
using System.Text;

namespace _11_2
{
    class Person
    {
        // 名
        public string FirstName { get; set; }
        // 姓 
        public string LastName { get; set; }

        public Gender GenderType { get; set; }


        // 姓名
        public string FullName
        {
            get
            {
                return LastName + FirstName;

            }
        }

        public  Person(string firstName ,string lastName, Gender genderType ) {

            FirstName = firstName;
            LastName = lastName;
            GenderType = genderType; 
        
        }



    }

    enum Gender
    {
        Male, Female
    }


}
