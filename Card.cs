using System;
using System.Collections.Generic;
using System.Text;

namespace KortSpel
{
    public class Card
    {
        //public string Name { get; set; }
        public Suits Suit { get; set; }
        public Values Value { get; set; }

        //public Card(Suits suit, Values value)
        //{
        //    Suit = suit;
        //    Value = value;
        //}

        public enum Values
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5, 
            Six = 6, 
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Knight = 11,
            Queen = 12,
            King = 13
        }

        public enum Suits
        {
            Spades = 4,
            Hearts = 3,
            Diamonds = 2,
            Cloves = 1,
            //Jokers
        }
    }
}
