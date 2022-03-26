using System;

namespace PlayingAroundWithInterfaces
{
    class Tallguy : IClown
    { 
        public string Name;
        public int Height;

        public string FunnyThingIHave => "ballon";

        public void Honk()
        {
            Console.WriteLine("Honk Honk");
        }

        public void TalkAboutYourself()
        {
            Console.WriteLine($"My Name is {Name} and I'm {Height} inches tall");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Tallguy tallguy = new Tallguy() {  Height = 76, Name = "Jimmy"};
            tallguy.TalkAboutYourself();
            Console.WriteLine($"The tall guy has {tallguy.FunnyThingIHave}");
            tallguy.Honk();

        }
    }
}
