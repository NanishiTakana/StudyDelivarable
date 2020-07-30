using System;
using System.Collections.Generic;
using System.Text;

namespace _14_1
{
    class CheerfulPet:VirtualPet
    {

        public CheerfulPet(string name) : base(name)
        {

        }

        public override void Eat()
        {
            Mood += 3;
            Energy += 5;
            Console.WriteLine("CheefullPet.Eatメソッドが実行されました");

        }
        public override void Play()
        {
            Mood += 2;
            Energy += 10;
            Console.WriteLine("CheefullPet.Playメソッドが実行されました");

        }

        public override void Sleep()
        {
            Mood += 4;
            Energy += 13;
            Console.WriteLine("CheefullPet.Sleepメソッドが実行されました");

        }


    }
}
