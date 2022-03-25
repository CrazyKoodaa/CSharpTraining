using System;

namespace randomStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Random random = new Random();
            int randomInt = random.Next();
            Console.WriteLine(randomInt);

            int zeroToNine = random.Next(10);
            Console.WriteLine(zeroToNine);

            int dieRoll = random.Next(1, 7);
            Console.WriteLine(dieRoll);

            double randomDouble = random.NextDouble();
            Console.WriteLine(randomDouble * 100);

            Console.WriteLine((float)randomDouble * 100f);
            Console.WriteLine((decimal)randomDouble * 100m);

            int zeroOrOne = random.Next(2);
            bool coinFlip = Convert.ToBoolean(randomDouble);
            Console.WriteLine(coinFlip);


        }
    }
}
