using System;
using System.Collections.Generic;
using System.Text;

namespace _14_1
{
    class SleepyPet:VirtualPet
    {
        public SleepyPet(string name) : base(name)
        {

        }

        public override void Eat()
        {
            Mood += 3;
            Energy += 5;
            Console.WriteLine("SleepyPet.Eatメソッドが実行されました");

        }
        public override void Play()
        {
            Mood += 2;
            Energy += 10;
            Console.WriteLine("SleepyPet.Playメソッドが実行されました");

        }

        public override void Sleep()
        {
            Mood += 4;
            Energy += 13;
            Console.WriteLine("SleepyPet.Sleepメソッドが実行されました");

        }

        public void Rest()
        {
            Mood += 13;
            Energy += 132;
            Console.WriteLine("SleepyPet.Restメソッドが実行されました");

        }


    }
}
