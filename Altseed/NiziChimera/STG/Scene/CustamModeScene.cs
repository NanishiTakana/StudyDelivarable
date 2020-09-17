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
        //UIを表示するレイヤーのインスタンスを作成
        asd.Layer2D UILayer = new asd.Layer2D();
        //名前を表示するレイヤーの作成
        asd.Layer2D NameLayer = new asd.Layer2D();
        //頭を表示するレイヤーのインスタンスを生成
        asd.Layer2D headLayer = new asd.Layer2D();
        //体を表示するレイヤーのインスタンスを生成
        asd.Layer2D bodyLayer = new asd.Layer2D();
        //足を表示するレイヤーのインスタンスを生成
        asd.Layer2D lowerLayer = new asd.Layer2D();
        //後ろ髪を表示するレイヤーのインスタンス作成
        asd.Layer2D hairLayer = new asd.Layer2D();


        //境界線を表示するレイヤーを作成する
        asd.Layer2D lineLayer = new asd.Layer2D();

        // マウスの状態を表示するテキストを生成する。
        asd.TextObject2D stateText;

        //カードのインスタンスを生成
        CardClass headCard = new CardClass("head");
        CardClass bodyCard = new CardClass("body");
        CardClass lowerCard = new CardClass("lower");
        CardClass hairCard = new CardClass("hair");

        //ボタンのインスタンスの生成
        ButtonClass randomButton = new ButtonClass(0);

        //境界線オブジェクトの生成

        asd.GeometryObject2D boundaryLineObj = new asd.GeometryObject2D();


        //名前オブジェクトの生成
        asd.TextObject2D[] name;
        List<asd.TextObject2D> name2 = new List<asd.TextObject2D>();


        //表示基準座標
        int xLine = 300;
        int yLine = 150;

        //幅比率
        float headRatio;
        float lowerRatio;

        Random randomNum = new System.Random();

        //カード番号
        //頭
        int headCardNum;
        //体
        int bodyCardNum;
        //足
        int lowerCardNum;


        protected override void OnRegistered()
        {
            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(UILayer);
            AddLayer(NameLayer);
            AddLayer(hairLayer);
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
            headCardNum = randomNum.Next(1, 5);
            //体
            bodyCardNum = randomNum.Next(1, 5);
            //足
            lowerCardNum = randomNum.Next(1, 5);

            ImageUnion(headCardNum, bodyCardNum, lowerCardNum);

            //ボタンの表示
            randomButton.Position = new asd.Vector2DF(500, 400);
            randomButton.Scale = new asd.Vector2DF(1, 1);

            name2.Clear();
            unionName();


            // レイヤーにオブジェクトのインスタンスを追加する。
            UILayer.AddObject(randomButton);
            hairLayer.AddObject(hairCard);
            headLayer.AddObject(headCard);
            bodyLayer.AddObject(bodyCard);
            lowerLayer.AddObject(lowerCard);

            headLayer.AddObject(stateText);

            lineLayer.AddObject(boundaryLineObj);


        }


        protected override void OnUpdated()
        {

            Click();
            randomButton.MouseOver();
            randomButton.MouseClick();

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
                if (randomButton.ScorpeJudge())
                {

                    Console.WriteLine(asd.Engine.Mouse.Position);

                    stateText.Text = "左ボタンが押されています。";

                    //文字列消去
                    for (int n = 0; n < name2.Count ;n++)
                    {
                        name2[n].Text = "";
                    }




                    //頭
                    headCardNum = randomNum.Next(1, 5);
                    //体
                    bodyCardNum = randomNum.Next(1, 5);
                    Console.WriteLine(bodyCardNum);
                    //足
                    lowerCardNum = randomNum.Next(1, 5);

                    ImageUnion(headCardNum, bodyCardNum, lowerCardNum);
                    name2.Clear();
                    unionName();
                }
                else
                {
                    stateText.Text = "左ボタンが押されていません。";
                }

            }

        }



        public void ImageUnion(int headNum, int bodyNum, int lowerNum)
        {
            // 体
            //画像の読み込み
            bodyCard.Texture = SystemDate.BodyCardTexture[bodyNum];


            //画像の中心点のY座標をデータファイルから取得
            int bodyCenterY = IntParse(bodyCard.getCardComponent(bodyNum, 9));
            bodyCard.CenterPosition = new asd.Vector2DF(bodyCard.Texture.Size.X / 2.0f, bodyCenterY);

            //頭と同じ座標に表示
            bodyCard.Position = new asd.Vector2DF(xLine, yLine);
            bodyCard.Scale = new asd.Vector2DF(0.5f, 0.5f);


            //頭
            //画像の読み込み
            headCard.Texture = SystemDate.HeadCardTexture[headNum];

            //画像の中心点のY座標をデータファイルから取得
            int headCenterY = IntParse(headCard.getCardComponent(headNum, 9));
            headCard.CenterPosition = new asd.Vector2DF(headCard.Texture.Size.X / 2.0f, headCenterY);

            //体と頭の大きさの比率を計算
            headRatio = (float)IntParse(bodyCard.getCardComponent(bodyNum, 8)) / IntParse(headCard.getCardComponent(headNum, 8));

            headCard.Position = bodyCard.Position;
            headCard.Scale = new asd.Vector2DF(0.5f * headRatio, 0.5f * headRatio);

            //後ろ髪
            if ((headCard.getCardComponent(headNum, 10) == "0"))
            {
                hairCard.Texture = SystemDate.HairTexture[0];
            }
            else
            {
                hairCard.Texture = SystemDate.HairTexture[headNum];
            }

            //画像の中心点をと位置を頭と合わせる
            hairCard.CenterPosition = headCard.CenterPosition;
            hairCard.Position = headCard.Position;

            //頭の比率を計算
            hairCard.Scale = headCard.Scale;


            //足
            lowerCard.Texture = SystemDate.LowerCardTexture[lowerNum];

            int lowerCenterY = IntParse(lowerCard.getCardComponent(lowerNum, 9));
            lowerCard.CenterPosition = new asd.Vector2DF(lowerCard.Texture.Size.X / 2.0f, lowerCenterY);

            int bodyUnionY = IntParse(bodyCard.getCardComponent(bodyNum, 10));

            //下半身と胴体の比率計算
            lowerRatio = (float)IntParse(bodyCard.getCardComponent(bodyNum, 11)) / IntParse(lowerCard.getCardComponent(lowerNum, 8));

            lowerCard.Position = new asd.Vector2DF
                (xLine + IntParse(bodyCard.getCardComponent(bodyNum, 12)) * 0.5f, bodyUnionY * 0.5f + bodyCard.Position.Y - bodyCenterY * 0.5f);


            lowerCard.Scale = new asd.Vector2DF(0.5f * lowerRatio, 0.5f * lowerRatio);
        }


        public void DrawLine(float position)
        {
            var boundaryLine = new asd.LineShape();
            boundaryLine.StartingPosition = new asd.Vector2DF(00, position);
            boundaryLine.EndingPosition = new asd.Vector2DF(800, position);
            boundaryLine.Thickness = 4;

            boundaryLineObj.Shape = boundaryLine;

        }

        public string getSplitName(int cardNo, string cardType)
        {

            if (cardType == "head")
            {
                return headCard.getCardComponent(cardNo, 11);
            }
            else if (cardType == "body")
            {
                return bodyCard.getCardComponent(cardNo, 13);
            }
            else if (cardType == "lower")
            {
                return lowerCard.getCardComponent(cardNo, 10);
            }
            else
            {
                return "?";
            }

        }


        public void unionName()
        {
            string headName = getSplitName(headCardNum, "head");
            string bodyName = getSplitName(bodyCardNum, "body");
            string lowerName = getSplitName(lowerCardNum, "lower");
            string unionName = headName + bodyName + lowerName;


            name = new asd.TextObject2D[unionName.Length];
            var font = asd.Engine.Graphics.CreateDynamicFont("", 40, new asd.Color(255, 255, 255, 255), 1, new asd.Color(0, 0, 0, 255));

            for (int n = 0; n < unionName.Length; n++)
            {
                //name[n] = new asd.TextObject2D();
                //name[n].Position = new asd.Vector2DF(30 , 50 + 50 * n);
                //name[n].Font = font;
                //name[n].Text = unionName[n].ToString();
                
                
                //

                name2.Add(new asd.TextObject2D());
                name2[n].Text = unionName[n].ToString();
                name2[n].Position = new asd.Vector2DF(30, 50 + 50 * n);
                name2[n].Font = font;



                //NameLayer.AddObject(name[n]);
                //NameLayer.Clear();
                NameLayer.AddObject(name2[n]);
            }

        }





    }

}
