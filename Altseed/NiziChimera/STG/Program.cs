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
			asd.Engine.Initialize("STG", 1280, 720, new asd.EngineOption());
			//asd.Engine.IsFullscreenMode = true;

			//初期データをロードする
			SystemDate.ButtonLoad();
			SystemDate.AllCardLoad();

			//

			TitleScene titleScene = new TitleScene();

			asd.Engine.ChangeSceneWithTransition(titleScene, new asd.TransitionFade(0, 1.0f));


			// Altseedのウインドウが閉じられていないか確認する。
			while (asd.Engine.DoEvents())
			{
				// もし、Escキーが押されていたらwhileループを抜ける。
				if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
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
