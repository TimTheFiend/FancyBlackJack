using FancyBlackJack.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Game
{
    public static class HandComparer
    {
        //true == player Wins; false == dealer wins
        public static EndStates CalculateWinningHand(Hand dealer, Hand player) {
            if (dealer.player is not Dealer && player.player is not Player)
                throw new Exception("`dealer` != dealer && `player` != player");


            EndStates state = EndStates.NONE;

            if ((state = CheckForBusts(dealer, player)) != EndStates.NONE)
                return state;

            if (dealer.Value == player.Value)   return EndStates.STALEMATE;
            if (dealer.Value > player.Value)    return EndStates.DEALER_WINS;
            if (dealer.Value < player.Value)    return EndStates.PLAYER_WINS;

            return EndStates.NONE;
        }

        private static EndStates CheckForBusts(Hand hand) {
            if (hand.player is Player) 
                return hand.isBust ? EndStates.DEALER_WINS : EndStates.NONE;

            return hand.isBust ? EndStates.PLAYER_WINS : EndStates.NONE;
        }

        private static EndStates CheckForBusts(Hand dealer, Hand player) {
            if (player.isBust)      return EndStates.DEALER_WINS;
            else if (dealer.isBust) return EndStates.PLAYER_WINS;
            
            return EndStates.NONE;
        }
    }

    public enum EndStates {
        NONE = 0,
        STALEMATE = 1,
        DEALER_WINS = 2,
        PLAYER_WINS = 3
    }
}
