using System;
using System.Collections.Generic;
using System.Text;

namespace _14_1
{
    class FoodiePet:VirtualPet
    {
        public FoodiePet(string name):base (name)
        {

        }

        public override void Eat()
        {
            Mood += 3;
            Energy += 5;
            Console.WriteLine("FoodiePet.Eatメソッドが実行されました");

        }
        public override void Play()
        {
            Mood += 2;
            Energy += 10;
            Console.WriteLine("FoodiePet.Playメソッドが実行されました");

        }

        public override void Sleep()
        {
            Mood += 4;
            Energy += 13;
            Console.WriteLine("FoodiePet.Sleepメソッドが実行されました");

        }



    }
}
