using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class CardClass
    {
        //カード番号
        public string CardNumber { get; set; }
        //ライバー名
        public string  FULLName { get; set; }
        public string SplitName { get; set; }
        //カードの属性
        public string CardType { get; set; }
        //カード説明
        public string CardExplanation { get; set; }



        //戦闘力パラメータ
        public int BattleParameter { get; set; }
        //狂気パラメータ
        public int InsanityParameter { get;set;}
        //頭脳パラメータ
        public int BrainParameter { get; set; }


        public CardClass( string cardNumber,  string fullName, string splitName, 
                         string cardType,
                         string cardExplanation,
                         int battleParameter,
                         int InsanityParameter,
                         int brainParameter)
        {
            this.CardNumber = cardNumber;
            this.FULLName = fullName;
            this.SplitName = splitName;
            this.CardType = cardType;
            this.CardExplanation = cardExplanation;

            this.BattleParameter = battleParameter;
            this.InsanityParameter = InsanityParameter;
            this.BrainParameter = battleParameter;

        }




    }
}
