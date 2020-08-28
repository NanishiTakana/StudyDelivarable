using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class GameScene : asd.Scene
    {
        //頭を表示するレイヤーを持つ
        asd.Layer2D headLayer;

        protected override void OnRegistered()
        {
            // 2Dを表示するレイヤーのインスタンスを生成する。
            headLayer = new asd.Layer2D();

            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(headLayer);
            Console.WriteLine("OK");




        }

    }
}
