using System;

namespace InterfaceTraining
{
    class TallGuy : IClown
    {
        public string Name;
        public int Height;
        
        //public string FunnyThingIHave 
        //{ 
        //    get { return "big shoes";  } 
        //}
        // or:
        public string FunnyThingIHave => "big shoes";


        public void Honk()
        {
            Console.WriteLine($"Honk honk!");
        }

        public void TalkAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
        }
    }



    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            TallGuy tallGuy = new TallGuy() { Name = "Jimmy", Height = 76 };
            tallGuy.TalkAboutYourself();
            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
            tallGuy.Honk();

        }
    }
}
