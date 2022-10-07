using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Character
{
    public class Player : BasePlayer
    {

        public int Wallet { get; private set; } = 500;


        //public bool AttemptBet(int betAmount) {
        //    if (Wallet - betAmount >= 0) {
        //        Wallet -= betAmount;
        //        return true;
        //    }
        //    return false;
        //}

        public int AttemptBet(int betAmount) {
            int actualBet = betAmount <= Wallet ? betAmount : Wallet;
            Wallet -= actualBet;

            return actualBet;
        }


        public int AttemptReturnBet(int betAmount, int remainingBetPool) {
            int actualBet = betAmount <= remainingBetPool ? betAmount : remainingBetPool;
            Wallet += actualBet;

            return actualBet;
        }

        public override string ToString() {
            return "PLAYER";
        }
    }
}
