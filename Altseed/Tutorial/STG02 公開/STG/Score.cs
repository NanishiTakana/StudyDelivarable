using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
	class Score : asd.TextObject2D
	{
	
		public Score()
		{
			//asd.Font font = asd.Engine.Graphics.CreateFont("Resources/Font.aff");
			asd.Font font = asd.Engine.Graphics.CreateDynamicFont(@"C:\WINDOWS\FONTS\MSGOTHIC.TTC", 24, new asd.Color(0, 0, 0, 255), 1, new asd.Color(255, 255, 255, 255));

			Font = font;

		}

		protected override void OnUpdate()
		{
			var scene = (GameScene)Layer.Scene;
			Text = "Score : " + scene.Score.ToString();
		}
	}
}
