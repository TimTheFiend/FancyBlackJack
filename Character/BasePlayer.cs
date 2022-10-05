using FancyBlackJack.CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Character
{
    public class BasePlayer
    {
        public Hand hand;

        public BasePlayer() {
            hand = new Hand(this);
        }
        //public PlayerActions GetInitialAction() {

        //}
    }
}
