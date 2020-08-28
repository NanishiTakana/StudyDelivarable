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
        //読み込んだカード情報の1行分を保持する
        string inputLine = "";
        //読み込んだカード情報を格納する変数
        ArrayList inputLineList = new ArrayList();

        protected override void OnRegistered()
        {
            // 2Dを表示するレイヤーのインスタンスを生成する。
            headLayer = new asd.Layer2D();

            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(headLayer);

            using (StreamReader sr = new StreamReader(
       "Resources/head.txt", Encoding.GetEncoding("UTF-8")))
            {

                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputLineList.Add(inputLine);
                }

                for (int i = 0; i < inputLineList.Count; i++)
                {
                    Console.WriteLine(inputLineList[i]);
                }


            }

        }
    }
}
