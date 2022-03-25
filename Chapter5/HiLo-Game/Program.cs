using System;


// Headfirst 252
                        
                                   
namespace HiLo_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Welcome to HiLo");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}.");
            HiLoGame.Hint();
            while (HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higher, l for lower, ? to buy a hint,");
                Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}");
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'h') HiLoGame.Guess(true);
                else if (key == 'l') HiLoGame.Guess(false);
                else if (key == '?') HiLoGame.Hint();
                else return;
            }
            Console.WriteLine("The Pot is empty. Bye :)");
        }
    }

    static class HiLoGame
    {
        public const int MAXIMUM = 10;
        private static Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);
        
        private static int pot = 10;

        public static void Guess(bool higher)
        {
            // currentNumber = random.Next(MAXIMUM);
            int nextNumber = random.Next(1, MAXIMUM + 1);

            if ((higher && nextNumber >= currentNumber) || (!higher && nextNumber <= currentNumber))
            {
                Console.WriteLine("You've guessed right!");
                pot++;

            }
            else
            {
                Console.WriteLine("Bad luckm yue guessed wrong");
                pot--;
            }
            currentNumber = nextNumber;
            Console.WriteLine($"The current number is {currentNumber}");

        }


        public static void Hint()
        {
            Console.Write($"The number is at {((currentNumber <= MAXIMUM / 2) ? "most" : "least")} {MAXIMUM / 2}");
            pot--;
        }

        public static int GetPot()
        {
            
            return pot;
        }
    }
}
