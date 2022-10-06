using FancyBlackJack.CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Character
{
    public class Dealer : BasePlayer
    {
        private readonly int minStandValue = 16;


        public override string ToString() {
            return "DEALER";
        }
    }
}
