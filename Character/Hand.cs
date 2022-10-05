using FancyBlackJack.CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Character
{
    public struct Hand 
    {
        /* Fields*/
        public List<Card> cards = new List<Card>();
        public BasePlayer player { get; private set; }
        public bool isSplit { get; private set; } = false;


        /* Properties */
        public bool isBust => GetTotalValue <= 21;  //blackjackNumber
        public int handSize => cards.Count;


        public int GetTotalValue {
            get {
                int totalHandValue = 0;

                var cardsSorted = cards.OrderByDescending(x => x.Value);
                Card lastCard = cardsSorted.Last();
                foreach (Card card in cardsSorted) {
                    // Handle Ace value change.
                    if (card.Value is CardValue.ACE) {
                        
                        // If `card` is the last card, and the valu
                        if (card == lastCard) {
                            totalHandValue += totalHandValue > 10 ? 1 : 11;  // If Ace would go above 21, add just 1.
                        }
                        else {
                            totalHandValue += 1;
                        }
                        //totalHandValue += totalHandValue > 10 ? 1 : 11;  // If Ace would go above 21, add just 1.
                        continue;
                    }
                    totalHandValue += card.GetValue;
                }

                return totalHandValue;
            }
        }

        #region Constructors
        public Hand(BasePlayer player) {
            this.player = player;
        }

        public Hand(BasePlayer player, List<Card> cards) : this(player) {
            this.cards = cards;
        }

        public Hand(BasePlayer player, params Card[] cards) : this(player, cards.ToList()) { }


        public Hand(Hand other, Card newCard) {
            this.player = other.player;
            this.isSplit = true;
            cards = new List<Card>() { newCard };
        }

        #endregion


        public void AddCard(Card card) {
            cards.Add(card);
        }

        public object Clone() {
            Card card = SplitHand();

            Hand other = (Hand)this.MemberwiseClone();
            //other.OnSplit(card);

            other.cards[0] = card;

            return other;
        }


        public static Hand SplitHand(Hand hand) {
            Card split = hand.SplitHand();
            

            return new Hand(hand, split);
        }


        private Card SplitHand() {
            /* Update value */
            this.isSplit = true;
            /* Split hand */
            Card card = cards[0];
            cards.Remove(card);


            return card;
        }

        public static bool operator ==(Hand hand, Hand other) {
            return hand.cards[0] == other.cards[0];
        }


        public static bool operator !=(Hand hand, Hand other) {
            return false;
        }



    }
}
