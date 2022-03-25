using System;

namespace AbilityScoreCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivedeBy = ReadDouble(calculator.DivedeBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimun");
                calculator.CalculateAbilityScore();
                Console.WriteLine($"Calculated ability score : {calculator.Score}");
                Console.WriteLine($"Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        private static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write($"{prompt} [{lastUsedValue}]: ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine($"   using value {value}");
                return value;
            }
            else
            {
                Console.WriteLine($"   using default value {lastUsedValue}");
                return lastUsedValue;
            }
        }

        private static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write($"{prompt} [{lastUsedValue}]: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int value))
            {
                Console.WriteLine($"   using value {value}");
                return value;
            }
            else
            {
                Console.WriteLine($"   using default value {lastUsedValue}");
                return lastUsedValue;
            }
        }
    }

    class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double DivedeBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            // Devide the roll result by the DivideBy field
            double divided = RollResult / DivedeBy;

            // Add AddAmount to the result of that devisiion
            // changed the += to a +
            // Issue:
            /*
             * With binary operators (yes binary means here, that two (binary) values gets combined
             * a = a + b;
             * is the same like
             * a += b;
             * Operators with += that combine a binary operator with an equals sign are called compund assignment operators.
             * 
             * f.e. because of this issue:
             * 
             * int q = (a = b + c);
             * will calculate a = b + c as usual. The operator returns a value, so it will update q with the result as well.
             * 
             * so:
             * int added = AddAmount += divided;
             * 
             * is just like doing this
             * 
             * int added = (AddAmount = AddAmount + divided);
             * 
             * AddAmount gets + with devided and updates the result to AddAmount, and then added gets the same value as AddAmount 
             * */

            int added = AddAmount + (int)divided;

            //If the result is too smal, use Minimum
            if (added < Minimum)
                Score = Minimum;
            else
                Score = added;


        }
    }
}
