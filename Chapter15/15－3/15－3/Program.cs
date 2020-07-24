using System;
using System.IO;

namespace _15_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteSample();
            }
            catch
            {
                Console.WriteLine("エラーが発生しました");
            }
        }

        private static void WriteSample()
        {
            using (var sw = new StreamWriter("sample.txt"))
            {
                sw.WriteLine(" 吾輩は猫である。");
                sw.WriteLine(" 名前はまだ無い");
                sw.WriteLine(" どこで生れ たかとんと見当がつかぬ。");
                Console.WriteLine("書き込み完了");
            }
        }
    }

}
