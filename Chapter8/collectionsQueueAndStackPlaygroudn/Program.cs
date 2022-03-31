using System;
using System.Collections.Generic;

namespace collectionsQueueAndStackPlaygroudn
{
    enum Flapjack
    {
        Crispy,
        Soggy,
        Browned,
        Banana,
    }

    class Lumberjack // the person
    {
        public string Name { get; private set; }
        private Stack<Flapjack> flapjackStack = new Stack<Flapjack>();
        public Lumberjack(string name)
        {
            this.Name = name;
        }
        
        public void TakeFlapjack(Flapjack jack)
        {
            flapjackStack.Push(jack);
        }

        public void EatFlapjack()
        {
            Console.WriteLine($"{Name} is eating flapjacks");
            while (flapjackStack.Count > 0)
            {
                Console.WriteLine($"{flapjackStack.Pop().ToString().ToLower()} flapjack");

            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Queue<Lumberjack> myQueue = new Queue<Lumberjack>();
            string name;

            Console.WriteLine("Hello World!");
            Console.Write("What's the first name: ");
            while ((name = Console.ReadLine()) != "") {
                Console.Write($"Number of flapjacks: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    Lumberjack lumberjack = new Lumberjack(name);
                    for (int i = 0; i < number; i++)
                        lumberjack.TakeFlapjack((Flapjack)random.Next(4));
                    myQueue.Enqueue(lumberjack);
                }
                Console.Write("Next lumberjack's name (blank to end): ");

            }
            while (myQueue.Count > 0)
            {
                Lumberjack next = myQueue.Dequeue();
                next.EatFlapjack();
            }

          
        }
    }
}
