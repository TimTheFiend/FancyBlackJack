using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FancyBlackJack.Character
{
    public class Player : BasePlayer
    {
        private readonly int startWallet = 500;

        //public int Wallet { get; private set; }
        public int Wallet { get; set; }
        //public int wallet = 500;

        public Player() {
            Wallet = startWallet;
        }
        //TODO FUCKEREN
        public bool AttemptBet(int betAmount) {
            if (Wallet - betAmount >= 0) {
                Wallet -= betAmount;
                return true;
            }
            return false;
        }

        //public bool AttemptBet(int betAmount, out int actualBet) {
        //    actualBet = Wallet > betAmount ? betAmount : Wallet;
        //    Wallet -= Wallet;
        //}

        //TODO: Remove when you can calculate winnings. maybe though???
        public void AddMoney(int bet) {
            Wallet += bet;
        }

        public void AddMoney(int bet, int winnings) {
            Wallet += bet + winnings;
        }



        public override string ToString() {
            return "PLAYER";
        }
    }
}
