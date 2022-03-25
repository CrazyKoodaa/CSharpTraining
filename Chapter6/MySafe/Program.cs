using System;

namespace MySafe
{
    class Safe
    {
        private string contents = "precious jewels";
        private string safeCombination = "12345";

        public string Open(string combination)
        {
            if (combination == safeCombination) return contents;
            return "";
        }

        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.Combination = safeCombination;
        }
    }

    class SafeOwner
    {
        private string valuables = "";
        public void ReceiveContents(string safeContents)
        {
            valuables = safeContents;
            Console.WriteLine($"Thank you for returning my {valuables}!");
        }
    }

    class Locksmith
    {
        public void OpenSafe(Safe safe, SafeOwner owner)
        {
            safe.PickLock(this);
            string safeContents = safe.Open(Combination);
            ReturnContents(safeContents, owner);
        }
        public string Combination { private get; set; }

        protected virtual void ReturnContents(string safeContents, SafeOwner owner)
        {
            owner.ReceiveContents(safeContents);
        }
    }

    class JewelThief : Locksmith
    {
        private string stolenJewels;
        protected override void ReturnContents(string safeContents, SafeOwner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}"   );
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SafeOwner owner = new SafeOwner();
            Safe safe = new Safe();
            JewelThief jewelthief = new JewelThief();
            jewelthief.OpenSafe(safe, owner);

            /* The JewelThief subclass hides a method in the Locksmith base class,
             * so you can get different behaviour from the same object based on the
             * reference you use to call it!
             * 
             * Declaring your JewelThief object as a Locksmith reference causes it to 
             * call the base class ReutrnContents() methog
             *
             * Locksmith calledAsLocksmith = new JewelThief();
             * calledAsLocksmith.ReturnContents(safeContents, owner);
             *
             * Declaring your JewelThief object as a JewelThief reference causes it to
             * call JuwelThief's ReturnContents() method instead, because it hides
             * the base class's method of the same name.
             *
             * JewelThief calledAsJewelThief = new JewelThief();
             * calledAsJewelThief.ReturnContents(safeContents, owner);
             */


            Console.ReadKey(true);

        }
    }
}
