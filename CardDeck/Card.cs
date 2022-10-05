using FancyBlackJack.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.CardDeck
{
    public class Card
    {
        /* Fields */
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }
        public bool IsFaceDown { get; private set; } = false;

        /* Magic Numbers */
        private static readonly int _aceFullValue = 11;
        private static readonly int _cardHighestValue = 10;


        #region Constructors
        public Card(CardSuit suit, CardValue value) {
            Suit = suit;
            Value = value;
        }
        
        public Card(CardSuit suit, CardValue value, bool isFaceDown) : this(suit, value){
            IsFaceDown = isFaceDown;
        }
        #endregion Constructors


        /// <summary>
        /// Returns the card's value as it's calculated in Black Jack. Aces default to full value.
        /// </summary>
        public int GetValue {
            get {
                // K | Q | J | 10
                if (Value >= CardValue.TEN) return (int)CardValue.TEN;
                // 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2
                if (Value >= CardValue.TWO) return (int)Value;
                
                // Ace full value.
                return _aceFullValue;
            }
        }


        /// <summary>
        /// Gets the unicode character representing the card's <see cref="Suit"/>,
        /// </summary>
        private string GetSuitUnicode {
            get {
                switch (Suit) {
                    case CardSuit.HEARTS:
                        return "♥";
                    case CardSuit.SPADES:
                        return "♠";
                    case CardSuit.DIAMONDS:
                        return "♦";
                    case CardSuit.CLUBS:
                        return "♣";
                    default:
                        throw new Exception("Card-object does not have a suit, also this will literally never happen.");
                }
            }
        }

        /// <summary>
        /// Returns the appropriate <see cref="ConsoleColor"/> based on the <see cref="CardSuit"/>, and if the card isn't <see cref="IsFaceUp"/>.
        /// </summary>
        public ConsoleColor GetColor {
            get {
                if (IsFaceDown) {
                    return ConsoleColor.Yellow;
                }
                return (int)Suit % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.Red;
            }
        }

        /// <summary>
        /// Returns the <see cref="Value"/> as a single character, I.E. "Ace" -> "A"; "Jack" -> "J", etc..<br></br>
        /// Used in conjunction with <see cref="GetSuitUnicode"/> for fancy printing.
        /// </summary>
        private string GetValueChar {
            get {
                if (Value > CardValue.ACE && Value < CardValue.JACK) return ((int)Value).ToString();
                return Value.ToString().Substring(0, 1);
            }
        }


        //TODO
        public void PrintCard() {

        }

        public override string ToString() {
            string output = !IsFaceDown ? $"{GetValueChar}{GetSuitUnicode}" : "¿?";
            return "[" + output + "]";
        }
    }
}
