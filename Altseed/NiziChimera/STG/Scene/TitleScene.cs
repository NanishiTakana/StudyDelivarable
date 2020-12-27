using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class TitleScene : asd.Scene
    {
        //UIを表示するレイヤーのインスタンスを作成
        asd.Layer2D UILayer = new asd.Layer2D();
        //カスタムモードシーンの作成
        CustamModeScene custamModeScene = new CustamModeScene();

        //ボタンのインスタンスの生成
        ButtonClass customButton = new ButtonClass(1);

        protected override void OnRegistered()
        {
            AddLayer(UILayer);

            //ボタンの表示
            customButton.Position = new asd.Vector2DF(400, 250);
            customButton.Scale = new asd.Vector2DF(1, 1);

            // レイヤーにオブジェクトのインスタンスを追加する。
            UILayer.AddObject(customButton);
        }



        protected override void OnUpdated()
        {
            Click();
            customButton.MouseOver();
            customButton.MouseClick();
        }

        public void Click()
        {
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                if (customButton.ScorpeJudge())
                {
                    asd.Engine.ChangeSceneWithTransition(custamModeScene, new asd.TransitionFade(0, 1.0f));
                }

            }
        }








    }
}
