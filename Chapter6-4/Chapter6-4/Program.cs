using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var array2d = new string[,]
            {
                { "sun", "日曜日" },
                { "mon", "月曜日" },
                { "tue", "火曜日" },
                { "wed", "水曜日" },
                { "thu", "木曜日" },
                { "fri", "金曜日" },
                { "sat", "土曜日" },
            };

            for (int n = 0; n <  array2d.GetLength(0) ;n++)
            {
                Console.WriteLine($"{array2d[n,1]} {(array2d[n,0])}");
            }


        }
    }
}
