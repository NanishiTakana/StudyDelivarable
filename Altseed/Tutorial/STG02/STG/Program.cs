﻿using System;
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

            asd.Engine.File.AddRootPackageWithPassword("Resources.pack", "1234");

            // タイトルのシーンのインスタンスを生成する。
            TitleScene scene = new TitleScene();

            // シーンを遷移する。
            asd.Engine.ChangeSceneWithTransition(scene, new asd.TransitionFade(0, 1.0f));

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
