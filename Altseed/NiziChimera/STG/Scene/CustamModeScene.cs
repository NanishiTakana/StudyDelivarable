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
        //体を表示するレイヤーを持つ
        asd.Layer2D lowerLayer;

        //読み込んだカード情報の1行分を保持する
        string inputLine = "";
        //カード情報の要素数
        int amoCardInfo = 8;

        //読み込んだカード情報の詳細を格納する変数
        string[] inputInfoList ;

        //読み込んだ頭カード情報の行分を格納する変数
        List<string[]> inputLineList = new List<string[]>() ;

        Random randomHead = new System.Random();

        //静的？
        //string headCardNum = randomHead.Next(1, 4).ToString("000");


        protected override void OnRegistered()
        {
            // 2Dを表示するレイヤーのインスタンスを生成する。
            headLayer = new asd.Layer2D();

            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(headLayer);

            inputInfoList = new string[amoCardInfo];
            GetCardInfo(inputInfoList,"head");
            GetCardInfo(inputInfoList, "body");
            GetCardInfo(inputInfoList, "lower");

            Console.WriteLine(inputLineList[1][0]);

        }

        private string[] GetCardInfo(string[] infoList,string getType)
        {
            using (StreamReader sr = new StreamReader($"Resources/{getType}.txt", Encoding.GetEncoding("UTF-8")))
            {

                while ((inputLine = sr.ReadLine()) != null)
                {
                    infoList = inputLine.Split(',');
                    inputLineList.Add(infoList);
                }
            }

            string CardNum = randomHead.Next(1, 4).ToString("000");

            asd.TextureObject2D headImage = new asd.TextureObject2D();
            headImage.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/{getType}/{getType}{CardNum}.png");
            Console.WriteLine($"Resources/{getType}/{getType}{CardNum}.png");
            headImage.Position = new asd.Vector2DF(320, 240);
            headImage.Scale = new asd.Vector2DF(0.5f, 0.5f);

            // レイヤーにオブジェクトのインスタンスを追加する。
            headLayer.AddObject(headImage);
            return infoList;
        }

    }


}
