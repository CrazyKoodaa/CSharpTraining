using System;

namespace animalSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Vertebrate
    {
        public virtual void Eat(Food morsel)
        {
            Swallow(morsel);
            Digest();
        }
    }

    class Chameleon : Vertebrate
    {
        public override void Eat(Food morsel)
        {
            CatchWithTongue(morsel);
            /* The next two lines can be replaced
            Swallow(morsel);
            Digest();
            * with 
            */
            base.Eat(morsel);
        }
    }
}
