using FancyBlackJack.CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Printing
{
    public static class UICard
    {
        public static void PrintCards(params Card[] cards) {
            var currentColor = UIHandler.Color;

            foreach (Card card in cards) {
                UIHandler.Color = card.GetColor;
                Console.Write(card);
            }

            UIHandler.Color = currentColor;
        }

        public static void PrintCards(IEnumerable<Card> cards) {
            var currentColor = UIHandler.Color;

            foreach (Card card in cards) {
                UIHandler.Color = card.GetColor;
                Console.Write(card);
            }

            UIHandler.Color = currentColor;
        }
    }
}
