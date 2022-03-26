using System;

namespace PlayingAroundWithInterfacesInheritance
{
    class FunnyFunny : IClown
    {
        private readonly string funnyThingIHave;
        public string FunnyThingIHave => funnyThingIHave;


        public void Honk()
        {
            Console.WriteLine($"Hi kids! I have a {funnyThingIHave}");
        }
        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }
    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private readonly int scaryThingCount;
        public ScaryScary(string funnyThing, int scaryThingCount) : base(funnyThing)
        {
            this.scaryThingCount = scaryThingCount;
        }
        public string ScaryThingIHave => $"{scaryThingCount} spiders";



        public void ScareLitteChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IClown fingersTheClown = new ScaryScary("bug red nose", 14);
            fingersTheClown.Honk();
            if (fingersTheClown is IScaryClown iScaryClownReference)
                iScaryClownReference.ScareLitteChildren();
        }
    }
}
