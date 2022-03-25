using System;

namespace Elephant
{
    public class Elephant
    {
        public string Name;
        public int EarSize;

        public void WhoAmI()
        {
            Console.WriteLine($"My name is {Name}");
            Console.WriteLine($"My ears are {EarSize} inches tall");
            
        }

        public void HearMessage(string message, Elephant whoSaidIt)
        {
            Console.WriteLine($"{Name} heard a message");
            Console.WriteLine($"{whoSaidIt.Name} said this: {message}");
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this);
        }

    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int choosingMenu;
            Console.WriteLine("Hello World!");

            Elephant lloyd = new Elephant() { Name="lloyd", EarSize=44};
            Elephant Lucinda = new Elephant() { Name = "Lucinda", EarSize = 32 };

            Elephant[] elephants = new Elephant[7];

            elephants[0] = new Elephant() { Name = "lloyd0", EarSize = 40 };
            elephants[1] = new Elephant() { Name = "lloyd1", EarSize = 33 };
            elephants[2] = new Elephant() { Name = "lloyd2", EarSize = 42 };
            elephants[3] = new Elephant() { Name = "lloyd3", EarSize = 32 };
            elephants[4] = new Elephant() { Name = "Lucinda4", EarSize = 44 };
            elephants[5] = new Elephant() { Name = "Lucinda5", EarSize = 37 };
            elephants[6] = new Elephant() { Name = "Lucinda6", EarSize = 45 };
            Elephant biggestEars = elephants[0];

            for (int i = 1; i < elephants.Length; i++)
            {
                Console.WriteLine($"Iteration #{i}");
                if (elephants[i].EarSize > biggestEars.EarSize)
                {
                    biggestEars = elephants[i];
                }
                Console.WriteLine($"Biggest Size is {biggestEars.EarSize}");
            }
            return;

            while (true)
            {
                Console.WriteLine("Press 1 for Lloyd, 2 for Lucinda and 3 to swap (0 to exit): ");
                Console.WriteLine("Don't press 4 :), 5 to say a message");
                
                choosingMenu = Convert.ToInt32(Console.ReadLine());

            
                switch (choosingMenu)
                {
                    case 1: lloyd.WhoAmI(); break;
                    case 2: Lucinda.WhoAmI(); break;
                    case 3:
                        Elephant temp = lloyd;
                        lloyd = Lucinda;
                        Lucinda = temp;
                        break;
                    case 4:
                        lloyd = Lucinda;
                        lloyd.EarSize = 4444;
                        lloyd.WhoAmI();
                        break;

                    case 5:
                        lloyd.HearMessage("Hi", Lucinda);
                        Console.WriteLine("Next try:");
                        Lucinda.SpeakTo(lloyd, "Hi, Lloyd!");
                        break;
                    case 0: return;
                }

            }


        }

        private static void swap(Elephant A, Elephant B)
        {

        }
    }
}
