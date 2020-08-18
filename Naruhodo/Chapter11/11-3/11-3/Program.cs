using System;

namespace _11_3
{
    class Program
    {
        static void Main()
        {
            var king = new Card(CardSuit.Spade, 13);
            Console.WriteLine($"Suit:{king.Suit}, Number:{king.Number}");
            ChangeToAce(king);
            Console.WriteLine($"Suit:{king.Suit}, Number:{king.Number}");
            
        }

        private static void ChangeToAce(Card card)
        {
            card = new Card(CardSuit.Club, 1);
            card.Number = 1;
            card.Suit = CardSuit.Heart;
        }
    }

    enum CardSuit
    {
        Club, Spade, Heart, Diamond
    }

    class Card
    {
       
        public CardSuit Suit { get; set; }
        public int Number { get; set; }

        public Card(CardSuit suit, int number)
        {
            Suit = suit;
            Number = number;
        }
    }
}
