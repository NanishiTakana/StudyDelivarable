using System;
using System.Collections.Generic;
using System.Text;

namespace AnotherSpase
{
    class Product
    {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        // コンス トラクタ 
        public Product( int code, string name, int price)
        { 
            this. Code = code;
            this. Name = name;
            this. Price = price; 
        }

        // 消費 税額 を 求める
        public int GetTax() {
            return (int)( Price * 0.08); 
        } // 税込 価格 を 求める
        public int GetPriceIncludingTax()
        {
            return Price + GetTax();
        }

    }
}
