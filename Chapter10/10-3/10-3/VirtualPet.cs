using System;
using System.Collections.Generic;
using System.Text;

namespace _10_3
{
    class VirtualPet
    {
        int _mood;
        public string Name { get; set; }
        public int Energy { get; set; }
        public int Mood
        {
            get
            {
                return _mood;
            }

            private set
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 10)
                {
                    value = 10;
                }
                else
                {
                    _mood = value;
                }


            }
        }



        public VirtualPet()
        {
            Name = Name;
            Mood = 5;
            Energy = 100;
        }

        public void MoodUp()
        {
            Mood += 1;
        }

        public void MoodDown()
        {
            Mood -= 1;
        }


    }
}
