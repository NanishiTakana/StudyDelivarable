using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_2
{
    class Arrayutils
    {
        public static int Getmin(int[] array, bool isPositive = false)
        {
            //もし、isPositive = trueなら、配列内の0以下の数字は0に初期化する
            if (isPositive)
            {
                for (int n = 0;n < array.Length; n++)
                {
                    if (array[n] < 0)
                    {
                        array[n] = 0;
                    }
                }
            }

            return array.Min();

        }

    }
}
