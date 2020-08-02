using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Altseedを初期化する。
            asd.Engine.Initialize("STG", 640, 480, new asd.EngineOption());

            // プレイヤーのインスタンスを生成する。
            Player player = new Player();

            // エンジンにプレイヤーのインスタンスを追加する。
            asd.Engine.AddObject2D(player);

            //　エンジンに敵のインスタンスを追加する。
            asd.Engine.AddObject2D(new Enemy(new asd.Vector2DF(320, 100), new asd.Vector2DF(0, 1), player));

            //　エンジンに敵のインスタンス2を追加する。(速度ベクトル : (1,0))
            asd.Engine.AddObject2D(new Enemy(new asd.Vector2DF(400, 150), new asd.Vector2DF(1, 0), player));

            //　エンジンに敵のインスタンス3を追加する。(速度ベクトル : (1,1))
            asd.Engine.AddObject2D(new Enemy(new asd.Vector2DF(140, 200), new asd.Vector2DF(1, 1), player));

            // Altseedのウインドウが閉じられていないか確認する。
            while (asd.Engine.DoEvents())
            {
                // もし、Escキーが押されていたらwhileループを抜ける。
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.ButtonState.Push)
                {
                    break;
                }
                // Altseedを更新する。
                asd.Engine.Update();
            }
            // Altseedの終了処理をする。
            asd.Engine.Terminate();
        }


    }



}
