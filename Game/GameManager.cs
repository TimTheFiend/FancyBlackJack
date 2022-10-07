using FancyBlackJack.CardDeck;
using FancyBlackJack.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Game
{
    public class GameManager : IBaseManager
    {
        /* Characters */
        Dealer dealer;
        Player player;

        /* Deck & Hands */
        Deck deck;
        List<Hand> hands;

        /* Manager-Classes */
        BetManager manBet;

        #region Constructor(s)
        public GameManager() {
            /* Characters */
            dealer = new Dealer();
            player = new Player();
            /* Deck & Hands */
            deck = new Deck();
            hands = new List<Hand>();
            /* Managers */
            manBet = new BetManager();
        }
        #endregion


        public void PlayBlackJack() {
            BetPhase(player);

            foreach (Hand hand in hands) {
                Console.WriteLine(hand);
            }
        }



        #region Phase 01 - Bet
        private void BetPhase(Player player) {
            int betValue = manBet.HandlePlayerBet(player);
            hands.Add(new Hand(player, betValue));
        }
        #endregion Phase 01 - Bet

        public void DebugPrintHands() {
            foreach (Hand hand in hands) {
                Console.WriteLine(hand);
            }
        }



        //TODO
        public void OnNewRound() {
            throw new NotImplementedException();
        }
    }
}
