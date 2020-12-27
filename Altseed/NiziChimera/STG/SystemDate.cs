using asd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public static class SystemDate
    {
        public static Texture2D[,] ButtonTexture;

        public static Texture2D[] HeadCardTexture;
        public static Texture2D[] BodyCardTexture;
        public static Texture2D[] LowerCardTexture;

        public static Texture2D[] HairTexture;

        public static void ButtonLoad()
        {

            int fileNum = 0;
            int fileType = 3;

            for (int n = 0; ; n++ )
            {

                if (!System.IO.File.Exists($"Resources/button/button{n}_0.png"))
                {
                    fileNum = n;
                    break;
                }

            }

            ButtonTexture = new Texture2D[fileNum, fileType];

            for (int n = 0; n < fileNum; n++ ) 
            {
                for (int m = 0; m < fileType; m++)
                {
                    ButtonTexture[n, m] = asd.Engine.Graphics.CreateTexture2D($"Resources/button/button{n}_{m}.png");
                }             

            }


        }

        public static void AllCardLoad( )
        {
            int headFileNum = FileCount("head");
            int bodyFileNum = FileCount("body");
            int lowerFileNum = FileCount("lower");

            HeadCardTexture = new Texture2D[headFileNum];
            BodyCardTexture = new Texture2D[bodyFileNum];
            LowerCardTexture = new Texture2D[lowerFileNum];
            HairTexture = new Texture2D[headFileNum]; 

            //頭ファイルの読み込み
            for (int m = 0; m < headFileNum; m++)
            {
                HeadCardTexture[m] = asd.Engine.Graphics.CreateTexture2D($"Resources/head/head{m.ToString("000")}.png");
            }
            //体ファイルの読み込み
            for (int m = 0; m < bodyFileNum; m++)
            {
                BodyCardTexture[m] = asd.Engine.Graphics.CreateTexture2D($"Resources/body/body{m.ToString("000")}.png");
                Console.WriteLine($"m:{m}");
            }
            //足ファイルの読み込み
            for (int m = 0; m < lowerFileNum; m++)
            {
                LowerCardTexture[m] = asd.Engine.Graphics.CreateTexture2D($"Resources/lower/lower{m.ToString("000")}.png");
            }
            //髪ファイルの読み込み
            for (int m = 0; m < headFileNum; m++)
            {
                if (System.IO.File.Exists($"Resources/hair/hair{m.ToString("000")}.png"))
                {
                    HairTexture[m] = asd.Engine.Graphics.CreateTexture2D($"Resources/hair/hair{m.ToString("000")}.png");
                }
                else
                {
                    HairTexture[m] = asd.Engine.Graphics.CreateTexture2D($"Resources/hair/hair000.png");
                }



            }


        }

        private static int FileCount(string cardType )
        {
            int FileNum = 0;

            for (int n = 0; ; n++)
            {
                if (!System.IO.File.Exists($"Resources/{cardType}/{cardType}{n.ToString("000")}.png"))
                {
                    FileNum = n;
                    break;
                }
            }

            return FileNum;

        }

        //String => Int変換メソッド
        public static int IntParse(string str)
        {
            int num = 0;
            if (int.TryParse(str, out num))
            {
                //Console.WriteLine($"変換成功{num}");
            }
            else
            {
                Console.WriteLine("数値に変換できません");
            }
            return num;
        }





    }
}
