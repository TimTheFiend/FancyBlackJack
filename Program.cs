// See https://aka.ms/new-console-template for more information



using FancyBlackJack.CardDeck;
using FancyBlackJack.Character;
using FancyBlackJack.Game;
using FancyBlackJack.InputHandler;
using FancyBlackJack.Printing;

Console.WriteLine("Hello World");

Player player = new Player();

BetManager.HandlePlayerBet(player);

return;
Card[] cards = new Card[] {
    new Card(CardSuit.DIAMONDS, CardValue.JACK),
    new Card(CardSuit.CLUBS, CardValue.THREE),
    new Card(CardSuit.SPADES, CardValue.QUEEN),
    new Card(CardSuit.SPADES, CardValue.ACE),
    new Card(CardSuit.HEARTS, CardValue.ACE, true),
};

UICard.PrintCards(cards);