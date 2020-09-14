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
        Texture2D defoltTexture;
        Texture2D holdTexture;
        Texture2D pushTexture;

        public ButtonClass(int fileNo)
        {

            defoltTexture = SystemDate.ButtonTexture[fileNo, 0];
            holdTexture = SystemDate.ButtonTexture[fileNo, 1];
            pushTexture = SystemDate.ButtonTexture[fileNo, 2];

            Texture = defoltTexture ;

        }


        protected override void OnUpdate()
        {
            base.OnUpdate();

        }


        public bool ScorpeJudge()
        {
            //ボタンの範囲内の場合、trueを返す

            return  asd.Engine.Mouse.Position.X > Position.X &&
                    asd.Engine.Mouse.Position.X < Position.X + Texture.Size.X &&
                    asd.Engine.Mouse.Position.Y > Position.Y &&
                    asd.Engine.Mouse.Position.Y < Position.Y + Texture.Size.Y ;

        }

        public void MouseOver()
        {
            // 左ボタンが押されているかを表示する。
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Free)
            {
                if (ScorpeJudge())
                {
                    Texture = holdTexture;

                }
                else
                {
                    Texture = defoltTexture;
                }

            }

        }

        public void MouseClick()
        {
            // 左ボタンが押されているかを表示する。
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                if (ScorpeJudge())
                {
                    Texture = pushTexture;

                }

            }

        }





    }
}
