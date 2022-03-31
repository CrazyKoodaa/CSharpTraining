using System;
using System.Collections.Generic;
using System.Linq;

namespace birdieWithIEnumerable
{
    class Bird
    {
        public string Name { get; set; }    
        public virtual void Fly(string destination)
        {
            Console.WriteLine($"{this} is flying to {destination}");
        }

        public override string ToString()
        {
            return $"A bird named {Name}";
        }
        public static void FlyAway(List<Bird> flock, string destiation)
        {
            foreach (Bird bird in flock)
            {
                bird.Fly(destiation);
            }
        }
    }

    class Duck : Bird
    {
        public int Size { get; set; }
        public KindOfDuck Kind { get; set; }
        public override string ToString()
        {
            return $"A {Size} inch {Kind}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Duck> ducks = new List<Duck>()
            {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17},
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18},
                new Duck() { Kind = KindOfDuck.Loon, Size = 14},
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11},
                new Duck() { Kind = KindOfDuck.Mallard, Size= 14},
                new Duck() { Kind = KindOfDuck.Loon, Size = 13},

            };

            // the next line won't work, because I am trying to upcast ducks to an bird list
            // Bird.FlyAway(ducks, "Minnesota");

            // I can safly upcast the ducks List to bird list if I use IENumarable and the upcast.ToList()
            IEnumerable<Bird> upcastDucks = ducks;
            Bird.FlyAway(upcastDucks.ToList(), "Minnesota");

        }
    }
}
