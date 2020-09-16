using asd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class CardClass : TextureObject2D
    {
        //カード番号
        public string cardNumber;
        //ライバー名
        public string fULLName;
        public string splitName;
        //カードの属性
        public string cardType;
        //カード説明
        public string cardExplanation;

        //戦闘力パラメータ
        public int battleParameter;
        //狂気パラメータ
        public int insanityParameter;
        //頭脳パラメータ
        public int brainParameter;

        //読み込んだカード情報の1行分を保持する
        string inputLine = "";
        //読み込んだカード情報の各値を格納する変数
        string[] inputInfoList;
        //読み込んだ頭カード情報の行分を格納する変数
        public List<string[]> inputLineList = new List<string[]>();

        //一覧からカードを読み込む
        public CardClass(string cardType)
        {



            if (cardType == "head")
            {
                getCardInfo("head");

            }
            else if (cardType == "body")
            {
                getCardInfo("body");
            }
            else if (cardType == "lower")
            {
                getCardInfo("lower");
            }

        }

        public void getCardInfo(string getType)
        {
            using (StreamReader sr = new StreamReader($"Resources/{getType}.csv", Encoding.GetEncoding("Shift-JIS")))
            {
                while ((inputLine = sr.ReadLine()) != null)
                {
                    inputInfoList = inputLine.Split(',');
                    inputLineList.Add(inputInfoList);
                }
            }

        }

        public string getCardComponent(int cardNo, int factorNo)
        {
            return inputLineList[cardNo][factorNo];

        }

    }



}
