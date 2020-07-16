using System;

namespace _11_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var parson = new Person("周那", "正山", Gender.Male);
            Console.WriteLine(parson.FullName);
            Console.WriteLine(parson.GenderType);

        }
    }


}
