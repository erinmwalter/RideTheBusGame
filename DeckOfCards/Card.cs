using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class Card
    {
        public string cardSuit;
        public int cardValue;
        public bool isCardRed;
        public string cardTitle;
        public string cardName;

        public Card()
        {
            cardSuit = "none";
            cardValue = -1;
            cardTitle = "none";
            isCardRed = false;
        }
        public Card(string suit, int value, string title, bool red)
        {
            cardSuit = suit;
            cardValue = value;
            cardTitle = title;
            isCardRed = red;
        }

        public void SetSuit(string suit)
        {
            cardSuit = suit;
        }
        public string GetSuit()
        {
            return cardSuit;
        }

        public void SetValue(int value)
        {
            cardValue = value % 13;
        }
        public int GetValue ()
        {
            return cardValue;
        }

        public void SetTitle(string title)
        {
            cardTitle = title;
        }
        public string GetTitle()
        {
            return cardTitle;
        }

        public void SetColor(bool color)
        {
            isCardRed = color;
        }
        public bool GetColor()
        {
            return isCardRed;
        }

        public void SetCardName()
        {
            cardName = $"{cardTitle} of {cardSuit}";
        }

        public string GetCardName()
        {
            return cardName;
        }
    }
}
