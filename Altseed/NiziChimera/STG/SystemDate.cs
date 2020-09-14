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


        public static void ButtonLoad()
        {

            int fileNum = 0;
            int fileType = 3;

            for (int n = 0; ; n++ )
            {

                if (System.IO.File.Exists($"Resources/button/button{n}_0.png"))
                {
                    fileNum = n +1;
                    Console.WriteLine(fileNum);
                }
                else
                {
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




    }
}
