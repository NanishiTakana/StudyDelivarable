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

            //表示基準線
            int xLine = 400;
            int yLine = 200;

            //頭
            CardClass headCard = new CardClass("head");
            Console.WriteLine(headCard.getCardComponent(1, 1));

            int headCardNum = randomNum.Next(1, 4);

            headCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/head/head{headCardNum.ToString("000")}.png");

            int centerY;
            if (int.TryParse(headCard.getCardComponent(headCardNum - 1, 9), out centerY))
            {
                headCard.CenterPosition = new asd.Vector2DF(headCard.Texture.Size.X / 2.0f, centerY);
            }
            else
            {
                Console.WriteLine("数値に変換できません");
            }
            headCard.Position = new asd.Vector2DF(xLine, yLine);
            headCard.Scale = new asd.Vector2DF(0.5f, 0.5f);


            //体
            CardClass bodyCard = new CardClass("body");
            Console.WriteLine(bodyCard.getCardComponent(1, 1));

            string bodyCardNum = randomNum.Next(1, 4).ToString("000");
            bodyCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/body/body{bodyCardNum}.png");
            bodyCard.Position = new asd.Vector2DF(490, 200);
            bodyCard.Scale = new asd.Vector2DF(0.5f, 0.5f);

            //足
            CardClass lowerCard = new CardClass("lower");
            Console.WriteLine(bodyCard.getCardComponent(1, 1));

            string lowerCardNum = randomNum.Next(1, 4).ToString("000");
            lowerCard.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/lower/lower{lowerCardNum}.png");
            lowerCard.Position = new asd.Vector2DF(490, 400);
            lowerCard.Scale = new asd.Vector2DF(0.5f, 0.5f);



            // レイヤーにオブジェクトのインスタンスを追加する。
            headLayer.AddObject(headCard);
            bodyLayer.AddObject(bodyCard);
            lowerLayer.AddObject(lowerCard);


        }


    }


}
