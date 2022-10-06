using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Character
{
    public class Player : BasePlayer
    {
        public int wallet = 500;

        public bool AttemptBet(int betAmount) {
            if (wallet - betAmount >= 0) {
                wallet -= betAmount;
                return true;
            }
            return false;
        }
    }
}
