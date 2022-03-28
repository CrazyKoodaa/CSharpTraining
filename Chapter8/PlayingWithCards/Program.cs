using System;
using System.Collections.Generic;

namespace PlayingWithCards
{
    class CardComparerByValue : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Suit < y.Suit) return -1;
            else if (x.Suit > y.Suit) return 1;
            else
            {
                if (x.Value < y.Value) return 1;
                else if (x.Value > y.Value) return -1;
                else return 0;
            }

        }
    }


    class Card
    {
        readonly static Random random = new Random();
        // private readonly List<Card> _cards = new List<Card>();

        public Values Value { get; private set; }
        public Suits Suit { get; private set; }
        public string Name { get { return $"{Value} of {Suit}"; } }
        /*public Card(Values value, Suits suit )
        {
            this.Value = value;
            this.Suit = suit;
        }*/

        public Card RandomCard()
        {
            int tValue = random.Next(1, 14);
            int tSuit = random.Next(3);
            Card tCard = new Card() { Suit = (Suits)tSuit, Value = (Values)tValue};
            return tCard;
        }
        public void PrintCards(List<Card> _cards)
        {
            for (int i = 0; i < _cards.Count; i++)
                Console.WriteLine(_cards[i].Name);
        }
    }



    internal class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            int numberBetween0and3 = random.Next(4);
            int numberBetween1and13 = random.Next(1,14);
            int anyRandomInteger = random.Next();

            Card cCard = new Card();

            List<Card> cards = new List<Card>();
            Console.Write("Enter number of cards: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfCards))
            {
                for (int i = 0; i < numberOfCards; i++)
                    cards.Add(cCard.RandomCard());
            }
            cCard.PrintCards(cards);

            cards.Sort(new CardComparerByValue());
            Console.WriteLine("\nSorting cards\n");
            cCard.PrintCards(cards);

            /*
            int score = (int)TrickScore.Fetch * 3; // catches the Number of Fetch and multiply the number 10 with 3
            Console.WriteLine(score);

            TrickScore whichTrick = (TrickScore)7; // the next line prints: The score is 30
            Console.WriteLine($"The score is {score}");

            LongTrickScore longTrick = (LongTrickScore)2500000000025; // <- get the name
            var longNumber = (long)LongTrickScore.Beg;                // <- get the number
            Console.WriteLine(longTrick);
            Console.WriteLine(longNumber);

            Card myCard = new Card(Values.Ace, Suits.Spades);
            Console.WriteLine(myCard.Name);
            */
            /*
            Card card = new Card((Values)numberBetween1and13, (Suits)numberBetween0and3);
            Console.WriteLine(card.Name);
            */
            /*
            Deck deck = new Deck();
            deck.PrintCards();
            */

        }
    }
    class Deck
    {
        //private readonly Card[] cards = new Card[52];
        private readonly List<Card> cards = new List<Card>();
        public Deck()
        {
            int index = -1;
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    // cards[++index] = new Card((Values)value, (Suits)suit);
                    //cards.Add(new Card((Values)value, (Suits)suit));

                }
            }
        }
        public void PrintCards()
        {
            for (int i = 0; i < cards.Count; i++)
                Console.WriteLine(cards[i].Name);
        }
    }
}
