// See https://aka.ms/new-console-template for more information



using FancyBlackJack.CardDeck;
using FancyBlackJack.InputHandler;
using FancyBlackJack.Printing;

Console.WriteLine("Hello World");


//InputReader.ModifierTest();

List<string> test;


return;
Card[] cards = new Card[] {
    new Card(CardSuit.DIAMONDS, CardValue.JACK),
    new Card(CardSuit.CLUBS, CardValue.THREE),
    new Card(CardSuit.SPADES, CardValue.QUEEN),
    new Card(CardSuit.SPADES, CardValue.ACE),
    new Card(CardSuit.HEARTS, CardValue.ACE, true),
};

UICard.PrintCards(cards);