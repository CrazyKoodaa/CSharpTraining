using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithCards
{
    enum Suits
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }

    enum Values
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }
    enum TrickScore
    {
        Sit = 7,
        Beg = 25,
        RollOver = 50,
        Fetch = 10,
        ComeHere = 5,
        Speak = 30,
    }

    enum LongTrickScore : long
    {
        Sit = 7,
        Beg = 2500000000025,
    }
}
