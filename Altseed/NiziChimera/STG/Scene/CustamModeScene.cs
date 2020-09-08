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
        //頭を表示するレイヤーのインスタンスを生成
        asd.Layer2D headLayer = new asd.Layer2D();
        //体を表示するレイヤーのインスタンスを生成
        asd.Layer2D bodyLayer = new asd.Layer2D();
        //足を表示するレイヤーのインスタンスを生成
        asd.Layer2D lowerLayer = new asd.Layer2D();
        //境界線を表示するレイヤーを作成する
        asd.Layer2D lineLayer = new asd.Layer2D();

        // マウスの状態を表示するテキストを生成する。
        asd.TextObject2D stateText;

        //カードのインスタンスを生成
        CardClass headCard = new CardClass("head");
        CardClass bodyCard = new CardClass("body");
        CardClass lowerCard = new CardClass("lower");

        //境界線オブジェクトの生成

        asd.GeometryObject2D boundaryLineObj = new asd.GeometryObject2D();

   
        //表示基準座標
        int xLine = 300;
        int yLine = 150;

        //幅比率
        float bodyRatio;
        float lowerRatio;

        Random randomNum = new System.Random();

        //カード番号
        //頭
        int headCardNum ;
        //体
        int bodyCardNum ;
        //足
        int lowerCardNum ;


        protected override void OnRegistered()
        {
            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(lowerLayer);
            AddLayer(bodyLayer);
            AddLayer(headLayer);
            AddLayer(lineLayer);

            var font = asd.Engine.Graphics.CreateDynamicFont("", 40, new asd.Color(255, 255, 255, 255), 1, new asd.Color(0, 0, 0, 255));
            stateText = new asd.TextObject2D();
            stateText.Position = new asd.Vector2DF(10, 10);
            stateText.Font = font;

            //各部位のランダム値を表示
            //頭
            headCardNum = randomNum.Next(1, 4);
            //体
            bodyCardNum = randomNum.Next(1, 4);
            //足
            lowerCardNum = randomNum.Next(1, 4);

            ImageUnion(headCardNum, bodyCardNum, lowerCardNum);

            // レイヤーにオブジェクトのインスタンスを追加する。
            headLayer.AddObject(headCard);
            bodyLayer.AddObject(bodyCard);
            lowerLayer.AddObject(lowerCard);
            headLayer.AddObject(stateText);
            lineLayer.AddObject(boundaryLineObj);


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

            // 左ボタンが押されているかを表示する。
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                stateText.Text = "左ボタンが押されています。";

                //頭
                headCardNum = randomNum.Next(1, 4);
                //体
                bodyCardNum = randomNum.Next(1, 4);
                //足
                lowerCardNum = randomNum.Next(1, 4);

                ImageUnion(headCardNum, bodyCardNum, lowerCardNum);

            }
            else
            {
                stateText.Text = "左ボタンが押されていません。";
            }

        }

        public void ImageUnion(int headNum, int bodyNum, int lowerNum)
        {
            //頭
            //画像の読み込み
            headCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/head/head{headNum.ToString("000")}.png");

            //画像の中心点のY座標をデータファイルから取得
            int headCenterY = IntParse(headCard.getCardComponent(headNum, 9));
            headCard.CenterPosition = new asd.Vector2DF(headCard.Texture.Size.X / 2.0f, headCenterY);

            headCard.Position = new asd.Vector2DF(xLine, yLine);
            headCard.Scale = new asd.Vector2DF(0.5f, 0.5f);
            DrawLine((int)headCenterY );

            //体
            //画像の読み込み
            bodyCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/body/body{bodyNum.ToString("000")}.png");

            //画像の中心点のY座標をデータファイルから取得
            int bodyCenterY = IntParse(bodyCard.getCardComponent(bodyNum , 9));
            bodyCard.CenterPosition = new asd.Vector2DF(bodyCard.Texture.Size.X / 2.0f, bodyCenterY);

            //頭と同じ座標に表示
            bodyCard.Position = headCard.Position;

            //DrawLine((int)bodyCard.Position.Y);

            //頭と体の大きさの比率を計算
            bodyRatio = (float)IntParse(headCard.getCardComponent(headNum , 8)) / IntParse(bodyCard.getCardComponent(bodyNum , 8));

            Console.WriteLine(bodyRatio);
            bodyCard.Scale = new asd.Vector2DF(bodyRatio * 0.5f, bodyRatio * 0.5f);

            //足
            lowerCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/lower/lower{lowerNum.ToString("000")}.png");

            int lowerCenterY = IntParse(lowerCard.getCardComponent(lowerNum, 9));
            lowerCard.CenterPosition = new asd.Vector2DF(lowerCard.Texture.Size.X / 2.0f, lowerCenterY);

            int bodyUnionY = IntParse(bodyCard.getCardComponent(bodyNum, 10));

            //下半身と胴体の比率計算
            lowerRatio = (float)IntParse(bodyCard.getCardComponent(bodyNum, 11)) / IntParse(lowerCard.getCardComponent(lowerNum, 8)) * bodyRatio;

            lowerCard.Position = new asd.Vector2DF
                (xLine, bodyUnionY * 0.5f * bodyRatio + bodyCard.Position.Y  - lowerCenterY * bodyRatio * 0.5f );
            //DrawLine((int)lowerCard.Position.Y);



            //DrawLine((float)bodyRatio * IntParse(bodyCard.getCardComponent(bodyNum, 11))  + bodyCard.Position.Y);

            lowerCard.Scale = new asd.Vector2DF(0.5f * lowerRatio , 0.5f * lowerRatio);
        }


        public void DrawLine(float position )
        {
            var boundaryLine = new asd.LineShape();
            boundaryLine.StartingPosition = new asd.Vector2DF(00, position);
            boundaryLine.EndingPosition = new asd.Vector2DF(800, position);
            boundaryLine.Thickness = 4;

            boundaryLineObj.Shape = boundaryLine;

        }

    }

}
