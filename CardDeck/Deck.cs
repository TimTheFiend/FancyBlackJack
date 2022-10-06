using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.CardDeck
{
    public class Deck
    {
        /* Constant values */
        private readonly int _amountCardsBicycleDeck = 52;

        /* Fields */
        public List<Card> cards { get; private set; }
        public int CardsRemaining => cards.Count;
        public int AmountOfDecks { get; private set; } = 6;


        public Deck() {
            cards = new List<Card>();
            PrepareDeck();
        }

        public void PrepareDeck() {
            //If more than half the original deck is still left.
            if (CardsRemaining >= (AmountOfDecks * _amountCardsBicycleDeck) / 2) {
                return;
            }

            CreateNewDeck();
            ShuffleDeck();
        }


        private void CreateNewDeck() {
            cards = new List<Card>();

            for (int i = 0; i < AmountOfDecks; i++) {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit))) {
                    foreach (CardValue value in Enum.GetValues(typeof(CardValue))) {
                        cards.Add(new Card(suit, value));
                    }
                }
            }
        }

        public Card DrawCard {
            get {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
        }

        private void ShuffleDeck() {
            Random rng = new Random();

            for (int i = 0; i < cards.Count - 1; i++) {
                int index = rng.Next(i, cards.Count);
                var temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }

        public static Deck GetDeck() {
            var deck = new Deck();
            deck.PrepareDeck();
            return deck;
        }

        public void DebugCreateCustomDeck(params Card[] cardsToUse) {
            cards = new List<Card>();

            cards.AddRange(cardsToUse);
        }
    }
}
