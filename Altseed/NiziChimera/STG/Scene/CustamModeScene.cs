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
        //名前を表示するレイヤーの作成
        asd.Layer2D StateLayer = new asd.Layer2D();
        //頭を表示するレイヤーのインスタンスを生成
        asd.Layer2D headLayer = new asd.Layer2D();
        //体を表示するレイヤーのインスタンスを生成
        asd.Layer2D bodyLayer = new asd.Layer2D();
        //足を表示するレイヤーのインスタンスを生成
        asd.Layer2D lowerLayer = new asd.Layer2D();
        //後ろ髪を表示するレイヤーのインスタンス作成
        asd.Layer2D hairLayer = new asd.Layer2D();
        //背景を表示するレイヤーのインスタンス作成
        asd.Layer2D BGLayer = new asd.Layer2D();


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

        static int nameLim = 20; //最大文字数
        static int descLim = 30; //最大説明文数
        static int stateNum = 3; //ステータス項目数

        //背景オブジェクトの生成
        asd.TextureObject2D backGround = new asd.TextureObject2D();

        //名前オブジェクトの生成
        asd.TextObject2D[] name = new asd.TextObject2D[nameLim];
        asd.TextObject2D[] headDesc = new asd.TextObject2D[descLim];
        asd.TextObject2D[] bodyDesc = new asd.TextObject2D[descLim];
        asd.TextObject2D[] lowerDesc = new asd.TextObject2D[descLim];


        //ステータスオブジェクトの生成
        //戦闘力
        asd.TextObject2D headStateB = new asd.TextObject2D();
        asd.TextObject2D bodyStateB = new asd.TextObject2D();
        asd.TextObject2D lowerStateB = new asd.TextObject2D();

        //知能
        asd.TextObject2D headStateI = new asd.TextObject2D();
        asd.TextObject2D bodyStateI = new asd.TextObject2D();
        asd.TextObject2D lowerStateI = new asd.TextObject2D();
        //狂気
        asd.TextObject2D headStateC = new asd.TextObject2D();
        asd.TextObject2D bodyStateC = new asd.TextObject2D();
        asd.TextObject2D lowerStateC = new asd.TextObject2D();


        //合計値
        asd.TextObject2D battleStateSum = new asd.TextObject2D();
        asd.TextObject2D intelligenceStateSum = new asd.TextObject2D();
        asd.TextObject2D crazyStateSum = new asd.TextObject2D();

        asd.Font font = asd.Engine.Graphics.CreateDynamicFont("", 40, new asd.Color(0, 0, 0, 0), 1, new asd.Color(255, 255, 255, 255));
        asd.Font stateFont = asd.Engine.Graphics.CreateDynamicFont("", 20, new asd.Color(0, 0, 0, 0), 1, new asd.Color(255, 255, 255, 255));
        asd.Font descFont = asd.Engine.Graphics.CreateDynamicFont("", 30, new asd.Color(0, 0, 0, 0), 1, new asd.Color(255, 255, 255, 255));

        //パーツ表示基準座標
        int xLine = 650;
        int yLine = 150;

        //パーツごとステータス座標
        int xPartsLine = 400;
        int yPartsLine = 100;

        //パーツごとの間隔
        int partsSpace = 200;

        //各パーツ値ごとの間隔
        int stateSpace = 30;

        //合計値標準座標
        int xStateLine = 950;
        int yStateLine = 300;

        //合計値同士の間隔
        int stateSumSpace = 70;

        //説明文位置
        int xDescPosition = 100;
        int yDescPosition = 100;
        int descSpace = 50;

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

        //カード最大値
        int maxCardNum = 6;
        //カード最小値
        int minCardNum = 1;


        protected override void OnRegistered()
        {
            // シーンにレイヤーのインスタンスを追加する。
            AddLayer(BGLayer);
            AddLayer(UILayer);
            AddLayer(NameLayer);
            AddLayer(StateLayer);

            AddLayer(hairLayer);
            AddLayer(lowerLayer);
            AddLayer(bodyLayer);
            AddLayer(headLayer);


            AddLayer(lineLayer);

            stateText = new asd.TextObject2D();
            stateText.Position = new asd.Vector2DF(10, 10);
            stateText.Font = font;

            //各state配列の初期化
            //フォントの初期化
            //戦闘力
            headStateB.Font = stateFont;
            headStateB.Position = new asd.Vector2DF(xPartsLine, yPartsLine);
            bodyStateB.Font = stateFont;
            bodyStateB.Position = new asd.Vector2DF(xPartsLine, yPartsLine + partsSpace);
            lowerStateB.Font = stateFont;
            lowerStateB.Position = new asd.Vector2DF(xPartsLine, yPartsLine + partsSpace * 2 );

            //知力
            headStateI.Font = stateFont;
            headStateI.Position = new asd.Vector2DF(xPartsLine, yPartsLine + stateSpace);
            bodyStateI.Font = stateFont;
            bodyStateI.Position = new asd.Vector2DF(xPartsLine, yPartsLine + partsSpace + stateSpace);
            lowerStateI.Font = stateFont;
            lowerStateI.Position = new asd.Vector2DF(xPartsLine, yPartsLine + partsSpace * 2 + stateSpace);

            //狂気
            headStateC.Font = stateFont;
            headStateC.Position = new asd.Vector2DF(xPartsLine, yPartsLine + stateSpace * 2);
            bodyStateC.Font = stateFont;
            bodyStateC.Position = new asd.Vector2DF(xPartsLine, yPartsLine + stateSpace * 2 + partsSpace);
            lowerStateC.Font = stateFont;
            lowerStateC.Position = new asd.Vector2DF(xPartsLine, yPartsLine + stateSpace * 2 + partsSpace * 2);

            //合計値
            battleStateSum.Font = font;
            intelligenceStateSum.Font = font;
            crazyStateSum.Font = font;
            battleStateSum.Position = new asd.Vector2DF(xStateLine, yStateLine);
            intelligenceStateSum.Position = new asd.Vector2DF(xStateLine, yStateLine + stateSumSpace);
            crazyStateSum.Position = new asd.Vector2DF(xStateLine, yStateLine + stateSumSpace * 2);

            //name配列の初期化
            SetStrArray_FontAndInstance(nameLim, name, NameLayer,font);

            //説明文配列の初期化
            SetStrArray_FontAndInstance(descLim,headDesc,StateLayer,descFont);
            SetStrArray_FontAndInstance(descLim, bodyDesc, StateLayer,descFont);
            SetStrArray_FontAndInstance(descLim, lowerDesc, StateLayer,descFont);

            //各部位のランダム値を表示
            //頭
            headCardNum = randomNum.Next(minCardNum, maxCardNum);
            //体
            bodyCardNum = randomNum.Next(minCardNum, maxCardNum);
            //足
            lowerCardNum = randomNum.Next(minCardNum, maxCardNum);

            //背景セット
            backGround.Texture = asd.Engine.Graphics.CreateTexture2D($"Resources/BackGround/Custom.png");

            //画像セット
            ImageUnion(headCardNum, bodyCardNum, lowerCardNum);

            //合計値セット
            battleStateSum.Text = $"戦：{GetCardState("Battle").ToString()}";
            intelligenceStateSum.Text = $"知：{GetCardState("Intelligence").ToString()}";
            crazyStateSum.Text = $"狂：{GetCardState("Crazy").ToString()}";

            //説明文のセット
            setDescText(headDesc, headCard.getCardComponent(headCardNum, 7), xDescPosition + descSpace * 2 );
            setDescText(bodyDesc, bodyCard.getCardComponent(bodyCardNum, 7), xDescPosition + descSpace);
            setDescText(lowerDesc, lowerCard.getCardComponent(lowerCardNum, 7), xDescPosition);


            //各部位の値セット
            StateSet();

            //ボタンの表示
            randomButton.Position = new asd.Vector2DF(900, 550);
            randomButton.Scale = new asd.Vector2DF(1, 1);

            UnionName();

            // レイヤーにオブジェクトのインスタンスを追加する。
            UILayer.AddObject(randomButton);
            hairLayer.AddObject(hairCard);
            headLayer.AddObject(headCard);
            bodyLayer.AddObject(bodyCard);
            lowerLayer.AddObject(lowerCard);

            StateLayer.AddObject(battleStateSum);
            StateLayer.AddObject(intelligenceStateSum);
            StateLayer.AddObject(crazyStateSum);

            //背景
            BGLayer.AddObject(backGround);

            //パーツごとステータスの追加
            //頭
            StateLayer.AddObject(headStateB);
            StateLayer.AddObject(headStateI);
            StateLayer.AddObject(headStateC);

            //体
            StateLayer.AddObject(bodyStateB);
            StateLayer.AddObject(bodyStateI);
            StateLayer.AddObject(bodyStateC);

            //下半身
            StateLayer.AddObject(lowerStateB);
            StateLayer.AddObject(lowerStateI);
            StateLayer.AddObject(lowerStateC);


            UILayer.AddObject(stateText);

            lineLayer.AddObject(boundaryLineObj);
        }


        protected override void OnUpdated()
        {
            Click();
            randomButton.MouseOver();
            randomButton.MouseClick();
        }



        public void Click()
        {
            // 左ボタンが押されているかを表示する。
            if (asd.Engine.Mouse.LeftButton.ButtonState == asd.MouseButtonState.Push)
            {
                if (randomButton.ScorpeJudge())
                {
                    //頭
                    headCardNum = randomNum.Next(minCardNum, maxCardNum);
                    //体
                    bodyCardNum = randomNum.Next(minCardNum, maxCardNum);
                    //足
                    lowerCardNum = randomNum.Next(minCardNum, maxCardNum);

                    ImageUnion(headCardNum, bodyCardNum, lowerCardNum);
                    UnionName();
                    battleStateSum.Text = $"戦：{GetCardState("Battle").ToString()}";
                    intelligenceStateSum.Text = $"知：{GetCardState("Intelligence").ToString()}";
                    crazyStateSum.Text = $"狂：{GetCardState("Crazy").ToString()}";

                    StateSet();

                    //説明文のセット
                    setDescText(headDesc, headCard.getCardComponent(headCardNum, 7), xDescPosition + descSpace * 2);
                    setDescText(bodyDesc, bodyCard.getCardComponent(bodyCardNum, 7), xDescPosition + descSpace);
                    setDescText(lowerDesc, lowerCard.getCardComponent(lowerCardNum, 7), xDescPosition);

                }
                else
                {

                }
            }

        }



        public void ImageUnion(int headNum, int bodyNum, int lowerNum)
        {
            // 体
            //画像の読み込み
            bodyCard.Texture = SystemDate.BodyCardTexture[bodyNum];

            //画像の中心点のY座標をデータファイルから取得
            int bodyCenterY = SystemDate.IntParse(bodyCard.getCardComponent(bodyNum, 9));
            bodyCard.CenterPosition = new asd.Vector2DF(bodyCard.Texture.Size.X / 2.0f, bodyCenterY);

            //表示
            bodyCard.Position = new asd.Vector2DF(xLine, yLine);
            bodyCard.Scale = new asd.Vector2DF(0.5f, 0.5f);


            //頭
            //画像の読み込み
            headCard.Texture = SystemDate.HeadCardTexture[headNum];

            //画像の中心点のY座標をデータファイルから取得
            int headCenterY = SystemDate.IntParse(headCard.getCardComponent(headNum, 9));
            headCard.CenterPosition = new asd.Vector2DF(headCard.Texture.Size.X / 2.0f, headCenterY);

            //体と頭の大きさの比率を計算
            headRatio = (float)SystemDate.IntParse(bodyCard.getCardComponent(bodyNum, 8)) / SystemDate.IntParse(headCard.getCardComponent(headNum, 8));

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

            int lowerCenterY = SystemDate.IntParse(lowerCard.getCardComponent(lowerNum, 9));
            lowerCard.CenterPosition = new asd.Vector2DF(lowerCard.Texture.Size.X / 2.0f, lowerCenterY);

            int bodyUnionY = SystemDate.IntParse(bodyCard.getCardComponent(bodyNum, 10));

            //下半身と胴体の比率計算
            lowerRatio = (float)SystemDate.IntParse(bodyCard.getCardComponent(bodyNum, 11)) / SystemDate.IntParse(lowerCard.getCardComponent(lowerNum, 8));

            lowerCard.Position = new asd.Vector2DF
                (xLine + SystemDate.IntParse(bodyCard.getCardComponent(bodyNum, 12)) * 0.5f, bodyUnionY * 0.5f + bodyCard.Position.Y - bodyCenterY * 0.5f);


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

        public string GetSplitName(int cardNo, string cardType)
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


        public void UnionName()
        {
            //文字列消去
            for (int n = 0; n < nameLim; n++)
            {
                name[n].Text = "";
            }

            string headName = GetSplitName(headCardNum, "head");
            string bodyName = GetSplitName(bodyCardNum, "body");
            string lowerName = GetSplitName(lowerCardNum, "lower");
            string unionName = headName + bodyName + lowerName;

            for (int n = 0; n < unionName.Length; n++)
            {
                name[n].Position = new asd.Vector2DF(800, 50 + 50 * n);
                name[n].Text = unionName[n].ToString();
            }

        }


        public void SetStrArray_FontAndInstance(int num, asd.TextObject2D[] textObject2D, asd.Layer2D layer , asd.Font font)
        {
            for (int n = 0; n < num; n++)
            {
                textObject2D[n] = new asd.TextObject2D();
                textObject2D[n].Font = font;
                layer.AddObject(textObject2D[n]);
            }

        }

        public int GetCardState(string stateType)
        {
            int state = 0;
            if (stateType == "Battle")
            {
                state = SystemDate.IntParse(headCard.getCardComponent(headCardNum, 4)) +
                        SystemDate.IntParse(bodyCard.getCardComponent(bodyCardNum, 4)) +
                        SystemDate.IntParse(lowerCard.getCardComponent(lowerCardNum, 4));
            }
            else if (stateType == "Intelligence")
            {
                state = SystemDate.IntParse(headCard.getCardComponent(headCardNum, 5)) +
                        SystemDate.IntParse(bodyCard.getCardComponent(bodyCardNum, 5)) +
                        SystemDate.IntParse(lowerCard.getCardComponent(lowerCardNum, 5));

            }
            else if (stateType == "Crazy")
            {
                state = SystemDate.IntParse(headCard.getCardComponent(headCardNum, 6)) +
                        SystemDate.IntParse(bodyCard.getCardComponent(bodyCardNum, 6)) +
                        SystemDate.IntParse(lowerCard.getCardComponent(lowerCardNum, 6));

            }

            return state;


        }

        public void StateSet()
        {
            //頭
            headStateB.Text = $"戦：{ headCard.getCardComponent(headCardNum, 4)}";
            headStateI.Text = $"知：{ headCard.getCardComponent(headCardNum, 5)}";
            headStateC.Text = $"狂：{ headCard.getCardComponent(headCardNum, 6)}";

            //体
            bodyStateB.Text = $"戦：{ bodyCard.getCardComponent(bodyCardNum, 4)}";
            bodyStateI.Text = $"知：{ bodyCard.getCardComponent(bodyCardNum, 5)}";
            bodyStateC.Text = $"狂：{ bodyCard.getCardComponent(bodyCardNum, 6)}";

            //下半身
            lowerStateB.Text = $"戦：{ lowerCard.getCardComponent(lowerCardNum, 4)}";
            lowerStateI.Text = $"知：{ lowerCard.getCardComponent(lowerCardNum, 5)}";
            lowerStateC.Text = $"狂：{ lowerCard.getCardComponent(lowerCardNum, 6)}";
        }

        public void setDescText(asd.TextObject2D[] text ,string description,int position) 
        {
            //文字列消去
            for (int n = 0; n < descLim; n++)
            {
                text[n].Text = "";
                text[n].Angle = 0;
            }

            //文字列設定
            for (int n = 0; n < description.Length; n++)
            {
 
                if(description[n] == '。')
                {
                    text[n].Angle = 90;
                    text[n].Position = new asd.Vector2DF(position + 56, 29 + 35 * n);
                }
                else if(description[n] == 'ー')
                {
                    text[n].Angle = 90;
                    text[n].Position = new asd.Vector2DF(position + 40, 28 + 35 * n);
                }
                else
                {
                    text[n].Position = new asd.Vector2DF(position, 20 + 35 * n);
                }

                text[n].Text = description[n].ToString();
            }


        }


    }

}
