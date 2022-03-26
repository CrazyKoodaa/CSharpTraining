using System;
// headfirst 297
namespace BirdyLaysEggs
{
    internal class BrokenEgg : Egg
    {
        /* The subclass constructor can have any number of parameters, and it can even be parameterless. 
         * It just needs to use the base keyword to pass the correct number of arguments to the base class constructor
         */
        public BrokenEgg(string color) : base(0, $"broken {color}")
        {
            Console.WriteLine("A bird laid a broken egg");
        }
    }
    class Egg
    {
        public double Size { get; private set; }
        public string Color { get; private set; }
        public Egg(double size, string color)
        {
            Size = size;
            Color = color;
        }
        public string Description
        {
            get { return $"A {Size:0.0}cm {Color} egg";  }
        }
    }

    abstract class Bird
    {
        public static Random Randomizer = new Random();
        public abstract virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return new Egg[0];
        }

    }

    class Pigeon : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if (Bird.Randomizer.Next(4) == 0)
                    eggs[i] = new BrokenEgg("white");
                else
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "white");
            }
            return eggs;
        }
    }


    class Ostrich : Bird
    {
        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12, "speckled");
            }
            return eggs;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Bird bird;
                Bird abstractBird = new Bird();
                Console.WriteLine("\nPress P for pigeon, O for ostrich: ");
                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (key)
                {
                    case 'P': bird = new Pigeon(); break;
                    case 'O': bird = new Ostrich(); break;
                    default: return;
                }
                Console.WriteLine("\nHow many eggs should it lay? ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
                Egg[] eggs = bird.LayEggs(numberOfEggs);
                foreach (Egg egg in eggs)
                {
                    Console.WriteLine(egg.Description);
                }
            }
        }
    }
}
