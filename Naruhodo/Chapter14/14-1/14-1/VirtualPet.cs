using System;
using System.Collections.Generic;
using System.Text;

namespace _14_1
{
    abstract class VirtualPet
    {
        public string Name { get; private set; }
        public int Mood { get; set; }
        public int Energy { get; set; }
        // コンス トラクター 
        public VirtualPet(string name)
        {
            Name = name;
            Mood = 5;
            Energy = 100;
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void Sleep();
        
    }
}
