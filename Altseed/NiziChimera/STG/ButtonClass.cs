using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using asd;

namespace STG
{
    class ButtonClass : TextureObject2D
    {
        public ButtonClass(string buttonName)
        {
            Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/button/{buttonName}.png");

        }


        public bool ScorpeJudge(float ratio)
        {
            //ボタンの範囲内の場合、trueを返す
            Console.WriteLine(Position.Y);
            Console.WriteLine(Position.Y + Texture.Size.Y);
            Console.WriteLine(Position.X);
            Console.WriteLine(Position.X + Texture.Size.X);

            return  asd.Engine.Mouse.Position.X > Position.X &&
                    asd.Engine.Mouse.Position.X < Position.X + Texture.Size.X  * ratio&&
                    asd.Engine.Mouse.Position.Y > Position.Y &&
                    asd.Engine.Mouse.Position.Y < Position.Y + Texture.Size.Y * ratio;

        }



    }
}
