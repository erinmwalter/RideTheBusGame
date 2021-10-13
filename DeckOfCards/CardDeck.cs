using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class CardDeck
    {
        public List<Card> InitializeDeck()
        {
            List<Card> deck = new List<Card>();

            for(int i = 0; i < 52; i++)
            {
                Card card = new Card(); //getting a new card object each pass
                //assigning the SUIT
                if (i <= 12)
                {
                    card.SetSuit("Hearts");
                }
                else if (i > 12 && i <= 25)
                {
                    card.SetSuit("Diamonds");
                }
                else if (i > 25 && i <= 38)
                {
                    card.SetSuit("Spades");
                }
                else
                {
                    card.SetSuit("Clubs");
                }

                //Assigning the COLOR
                if (i <= 25)
                {
                    card.SetColor(true);
                }
                else
                {
                    card.SetColor(false);
                }

                //assigning the VALUE
                card.SetValue(i);

                //assiging the TITLE
                if (i == 12 || i == 25 || i == 38 || i == 51)
                {
                    card.SetTitle("Ace");
                }
                else if (i == 11 || i == 24 || i == 37 || i == 50)
                {
                    card.SetTitle("King");
                }
                else if (i == 10 || i == 23 || i == 36 || i == 49)
                {
                    card.SetTitle("Queen");
                }
                else if (i == 9 || i == 22 || i == 35 || i == 48)
                {
                    card.SetTitle("Jack");
                }
                else if (i < 12)
                {
                    card.SetTitle($"{(i + 2) % 11}");
                }
                else if (i < 22)
                {
                    card.SetTitle($"{(i - 11) % 11}");
                }
                else if (i < 36)
                {
                    card.SetTitle($"{(i - 24) % 11}");
                }
                else
                {
                    card.SetTitle($"{(i - 37) % 11}");
                }

                card.SetCardName();

                deck.Add(card);
            }

            return deck;
        }
    }
}
