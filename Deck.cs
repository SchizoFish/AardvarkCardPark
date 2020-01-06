using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KortSpel
{
    class Deck : Card
    {
        private const int numOfCards = 52;
        private static Card[] cardDeck = new Card[numOfCards];

        public static Card[] playDeck { get { return cardDeck; } }

        public static void createDeck()
        {
            int temp = 0;

            foreach (Suits s in Enum.GetValues(typeof(Suits)))
            {
                foreach (Values v in Enum.GetValues(typeof(Values)))
                {
                    cardDeck[temp] = new Card { Suit = s, Value = v };
                    temp++;
                }
            }
        }

        public void GetFirstCard()
        {
            Console.WriteLine(cardDeck.First()); 
        }

        public static Card[] PutCardLast()
        {
            var newDeck = new Card[numOfCards];
            int count = 0;

            for (int i = 1; i < cardDeck.Length; i++)
            {
                newDeck[count] = cardDeck[i];
                count++;
            }

            newDeck[newDeck.Length - 1] = cardDeck.First();

            return cardDeck = newDeck.ToArray();
        }

    }
}
