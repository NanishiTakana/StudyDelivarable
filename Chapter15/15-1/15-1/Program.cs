using System;

namespace _15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[5]
                {
                    1,2,2,2,4
                };

            try
            {
                Console.WriteLine(array[5]);
            }
            catch(Exception ex)
            {
                Console.WriteLine( $"Type : {ex.GetType().Name}");
                Console.WriteLine($"Type : {ex.Message}");
            }



        }
    }
}
