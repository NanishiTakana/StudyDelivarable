using System;
using System.IO;

namespace _9_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //課題9-3-1
            var lines = File.ReadAllLines(@"..\..\..\..\..\gion.txt");
            var lineLength = 0;
            foreach (var line in lines)
            {
                lineLength += line.Length; 
            }
            Console.WriteLine($"読み込んだファイルの文字数は、{lineLength}文字です");

            //課題9-3-3
            foreach (var line in lines)
            {
                
                foreach(var splotLine in line.Split('、'))
                {
                    Console.WriteLine(splotLine);
                }

            }



        }
    }
}
