using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runAgain = true;
            CardDeck deckBuilder = new CardDeck();
            List<Card> newDeck = deckBuilder.InitializeDeck();
            List<List<Card>> allHands = new List<List<Card>>();
            Dictionary<string, List<Card>> allPlayerHands = new Dictionary<string, List<Card>>();
            string playerName;
            
            Card drawnCard = new Card();
            Card firstCard = new Card();
            Card secondCard = new Card();


            Console.WriteLine("Let's Play Ride The Bus!\n");
            while (runAgain && newDeck.Count > 0)
            {
                List<Card> playerHand = new List<Card>();

                playerName = GetInput("Enter Player's Name: ");

                firstCard = DrawCard(newDeck, newDeck.Count);
                
                playerHand.Add(firstCard);
                newDeck.Remove(firstCard);
                PlayRedOrBlack(firstCard);

                secondCard = DrawCard(newDeck, newDeck.Count);
                playerHand.Add(secondCard);
                newDeck.Remove(secondCard);
                PlayHigherOrLower(secondCard, firstCard.GetValue(), secondCard.GetValue());

                drawnCard = DrawCard(newDeck, newDeck.Count);
                playerHand.Add(drawnCard);
                newDeck.Remove(drawnCard);
                PlayOutsideOrInBetween(firstCard, secondCard, drawnCard);

                drawnCard = DrawCard(newDeck, newDeck.Count);
                playerHand.Add(drawnCard);
                newDeck.Remove(drawnCard);
                PlayGuessTheSuit(drawnCard);



                allPlayerHands.Add(playerName, playerHand);
                runAgain = Continue("\nAnother Player's Turn? (y/n): ");
            }

            
            foreach (KeyValuePair<string, List<Card>> hand in allPlayerHands)
            {
                Console.WriteLine($"\n{hand.Key}'s hand: ");
                foreach(Card card in hand.Value)
                {
                    Console.WriteLine(card.GetCardName());
                }
            } 
         
        }

        public static Card DrawCard(List<Card> newDeck, int size)
        {
            int cardNum;
            Random randNum = new Random();
            Card drawnCard = new Card();

            cardNum = randNum.Next(0, size);
            drawnCard = newDeck[cardNum];

            return drawnCard;
        }

        public static bool Continue(string prompt)
        {
            string answer;
            Console.Write(prompt);
            answer = Console.ReadLine().ToLower();

            if(answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nSorry, I didn't understand, let's try again...");
                return Continue(prompt);
            }
        }

        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            return userInput;
        }

        //this method will prompt user for color and compare to the color of the card. 
        public static void PlayRedOrBlack(Card drawnCard)
        {
            Console.WriteLine("Ok, first let's guess the color...");
            string guess = GetInput("Red or Black?: ").ToLower();
            string cardColor;
            Console.WriteLine($"You Drew the {drawnCard.GetCardName()}");
            ;
            if (drawnCard.GetColor())
            {
                cardColor = "red";
            }
            else
            {
                cardColor = "black";
            }

            if (guess == cardColor)
            {
                Console.WriteLine("You are correct!");
            }
            else
            {
                Console.WriteLine("You Suck... DRINK!");
            }
        }

        public static void PlayGuessTheSuit(Card drawnCard)
        {
            Console.WriteLine("Ok and now time to guess the suit...");
            string suitGuess = GetInput("Guess the Suit?").ToLower();
            Console.WriteLine($"You Drew the {drawnCard.GetCardName()}");
            if (suitGuess == drawnCard.GetSuit().ToLower())
            {
                Console.WriteLine("You are correct!");
            }
            else
            {
                Console.WriteLine("You suck... DRINK!");
            }
        }

        public static void PlayHigherOrLower(Card card, int originalCard, int drawnCard)
        {
            string userGuess = GetInput($"Now, Higher or Lower?: ").ToLower();
            Console.WriteLine($"You Drew the {card.GetCardName()}");
            if (userGuess == "higher" && drawnCard > originalCard)
            {
                Console.WriteLine("Good Job, you are correct!");
            }
            else if (userGuess == "lower" && drawnCard < originalCard)
            {
                Console.WriteLine("Good Job, you are correct!");
            }
            else
            {
                Console.WriteLine("You Suck...DRINK!");
            }
        }

        public static void PlayOutsideOrInBetween(Card first, Card second, Card newCard)
        {
            int min, max;

            string userGuess = GetInput("Ok, now guess Outside or In-between:").ToLower();
            Console.WriteLine($"You Drew the {newCard.GetCardName()}");
            if(first.GetValue() >= second.GetValue())
            {
                min = second.GetValue();
                max = first.GetValue();
            }
            else
            {
                min = first.GetValue();
                max = second.GetValue();
            }

            if (userGuess == "outside" && (newCard.GetValue() > max || newCard.GetValue() < min)) 
            {
                Console.WriteLine("You are correct!");

            }
            else if (userGuess == "in-between" && (newCard.GetValue() <= max && newCard.GetValue() >= min)) 
            {
                Console.WriteLine("You are Correct!");
            }
            else
            {
                Console.WriteLine("You suck... DRINK!");
            }
                
        }
    }
}
