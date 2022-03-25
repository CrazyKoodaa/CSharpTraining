using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickACardUI
{
    public class CardPicker
    {
        static Random Random = new Random();
        /// <summary>
        /// Picks a number of cards and return them.
        /// </summary>
        /// <param name="numberOfCards">The number of cards to pick</param>
        /// <returns>An array of strings that contain the card names.</returns>
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuite();
            }
            return pickedCards;
        }

        private static string RandomSuite()
        {
            int value = Random.Next(1,5);
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";

        }

        private static string RandomValue()
        {
            int value = Random.Next(1,14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();

        }
    }
}
