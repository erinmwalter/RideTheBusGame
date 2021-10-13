# RideTheBusGame

For this project, my goal was to make a deck of cards, by making each card as an object, and then combining all these objects into a list of objects AKA the deck of cards.

Each Card Object has the following properties:
-Card Name (AKA "Queen of Hearts")
-Card Title (AKA "Queen")
-Card Value (0-12 based on value 2-Ace being high)
-Card Color (true = red, false = black)
-Card Suit (Hearts, Diamonds, Spaces, or Clubs)

Upon making a new list of these card objects and calling "Initialize Deck", this will initialize a new deck with all 52 cards in it. 

Once I made and initialized a deck of cards, I worked to create a method to enable a user to draw a card, and for this card to not only be added to their hand but also
deleted from the card deck list.

Once making this card draw functionality, I decided to test this deck of cards I had programmed with a classic drinking game: ride the bus.
-Users first select a color, then the card is drawn. If it does not match what they selected, they drink.
-Next is Higher or Lower, so they have to guess whether the next card will be higher or lower than the previous card. If they are wrong, they drink.
-Next is Outside or In Between the values of the first two cards, if they are wrong, they drink.
-Last is guess the suit, then the card is drawn, if the user is wrong, they drink.

I will add to this program as I write more of the program, right now the game stops after this portion of the game. 
