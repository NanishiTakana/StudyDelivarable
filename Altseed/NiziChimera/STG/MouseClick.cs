using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class MouseClick
    {
        public void Click()
        {
            // マウスの状態を表示するテキストを生成する。
            var font = asd.Engine.Graphics.CreateDynamicFont("", 40, new asd.Color(255, 255, 255, 255), 1, new asd.Color(0, 0, 0, 255));

            // マウスの左ボタンをクリックしたか否かを表示する文字描画オブジェクトを設定して、エンジンに追加する。
            var stateText = new asd.TextObject2D();
            stateText.Position = new asd.Vector2DF(10, 10);
            stateText.Font = font;

            // 左ボタンが押されているかを表示する。
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Hold)
            {
                stateText.Text = "左ボタンが押されています。";
            }
            else
            {
                stateText.Text = "左ボタンが押されていません。";
            }

            asd.Engine.AddObject2D(stateText);

        }



    }
}
