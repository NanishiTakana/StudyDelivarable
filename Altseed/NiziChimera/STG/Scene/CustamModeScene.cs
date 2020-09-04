using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class CustamModeScene : asd.Scene
    {
        //頭を表示するレイヤーを持つ
        asd.Layer2D headLayer;
        //体を表示するレイヤーを持つ
        asd.Layer2D bodyLayer;
        //足を表示するレイヤーを持つ
        asd.Layer2D lowerLayer;


        Random randomNum = new System.Random();

        protected override void OnRegistered()
        {
            // 2Dを表示するレイヤーのインスタンスを生成する。
            headLayer = new asd.Layer2D();
            bodyLayer = new asd.Layer2D();
            lowerLayer = new asd.Layer2D();

            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(lowerLayer);
            AddLayer(bodyLayer);
            AddLayer(headLayer);

            //表示基準座標
            int xLine = 300;
            int yLine = 150;

            //幅比率
            float bodyRatio;
            float lowerRatio;


            //頭
            CardClass headCard = new CardClass("head");

            int headCardNum = randomNum.Next(1, 4);
            //画像の読み込み
            headCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/head/head{headCardNum.ToString("000")}.png");

            Console.WriteLine($"headcardnum:{headCardNum}");
            //画像の中心点のY座標をデータファイルから取得
            int headCenterY = IntParse(headCard.getCardComponent(headCardNum - 1, 9));
            headCard.CenterPosition = new asd.Vector2DF(headCard.Texture.Size.X / 2.0f, headCenterY);

            headCard.Position = new asd.Vector2DF(xLine, yLine);
            headCard.Scale = new asd.Vector2DF(0.5f, 0.5f);


            //体
            CardClass bodyCard = new CardClass("body");

            int bodyCardNum = randomNum.Next(1, 4);
            Console.WriteLine($"bodycardnum:{bodyCardNum}");
            //画像の読み込み
            bodyCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/body/body{bodyCardNum.ToString("000")}.png");

            //画像の中心点のY座標をデータファイルから取得
            int bodyCenterY = IntParse(bodyCard.getCardComponent(bodyCardNum - 1, 9));
            bodyCard.CenterPosition = new asd.Vector2DF(bodyCard.Texture.Size.X / 2.0f, bodyCenterY);

            //頭と同じ座標に表示
            bodyCard.Position = headCard.Position;
            Console.WriteLine("test");
            //頭と体の大きさの比率を計算
            bodyRatio = (float)IntParse(headCard.getCardComponent(headCardNum - 1, 8)) / 
                        IntParse(bodyCard.getCardComponent(bodyCardNum - 1, 8)) ;

            Console.WriteLine("test2");

            bodyCard.Scale = new asd.Vector2DF(bodyRatio * 0.5f, bodyRatio * 0.5f);

            //足
            CardClass lowerCard = new CardClass("lower");

            int lowerCardNum =  randomNum.Next(1, 4);
            Console.WriteLine($"lowerCardNum{lowerCardNum}");
            lowerCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/lower/lower{lowerCardNum.ToString("000")}.png");


            int lowerCenterY = IntParse(lowerCard.getCardComponent(lowerCardNum - 1, 9));
            lowerCard.CenterPosition = new asd.Vector2DF(lowerCard.Texture.Size.X / 2.0f, lowerCenterY);

            int bodyUnionY = IntParse(bodyCard.getCardComponent(bodyCardNum - 1, 10));
            lowerCard.Position = new asd.Vector2DF(xLine, bodyUnionY / 2.0f + bodyCard.Position.Y);

            lowerCard.Scale = new asd.Vector2DF(0.5f, 0.5f);

            // レイヤーにオブジェクトのインスタンスを追加する。
            headLayer.AddObject(headCard);
            bodyLayer.AddObject(bodyCard);
            lowerLayer.AddObject(lowerCard);




        }

        protected override void OnUpdated()
        {

            Click();
        }


        //String => Int変換メソッド
        public int IntParse(string str)
        {
            int num = 0;
            if (int.TryParse(str, out num))
            {
                Console.WriteLine($"変換成功{num}");
            }
            else
            {
                Console.WriteLine("数値に変換できません");
            }
            return num;

        }

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
