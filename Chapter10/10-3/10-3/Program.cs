using System;

namespace _10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var virtualPet = new VirtualPet();
            Console.WriteLine(virtualPet.Mood);

            //10より大きくにならないか確認
            for (int n = 0; n < 6; n++)
            {
                virtualPet.MoodUp();
                Console.WriteLine(virtualPet.Mood);
            }
            //1より小さくならないか確認
            for(int n = 0; n < 13; n++)
            {
                virtualPet.MoodDown();
                Console.WriteLine(virtualPet.Mood);
            }
        }
    }
}
