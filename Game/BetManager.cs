using FancyBlackJack.Character;
using FancyBlackJack.InputHandler;

namespace FancyBlackJack.Game
{
    public class BetManager : IBaseManager
    {
        private static readonly int _bet10 = 10;
        private static readonly int _bet50 = _bet10 * 5;
        private static readonly int _bet100 = _bet10 * 10;
        private static readonly int _bet200 = _bet10 * 20;
        private static readonly int _bet500 = _bet10 * 50;

        private static readonly int[] bets = new int[] {
            _bet10,
            _bet50,
            _bet100,
            _bet200,
            _bet500
        };


        public int CurrentBettingPool { get; private set; } = 0;

        public int HandlePlayerBet(Player player) {
            CurrentBettingPool = 0;
#if DEBUG
            DebugPrintInstructions();
#endif

            while (true) {
                // .ReadPlayerBet returns the unedited value. -1 for the accurate bet index.
                int userInput = InputReader.ReadPlayerBet(bets.Count(), out bool isRemovingBet) - 1;
                
                //Check if player is done betting.
                if (userInput < 0) { return CurrentBettingPool; }

                int _bet = bets[userInput];

                if (isRemovingBet) {
                    //Check if visual update is needed.
                    CurrentBettingPool -= player.AttemptReturnBet(_bet, CurrentBettingPool);
                    continue;
                }
                CurrentBettingPool += player.AttemptBet(_bet);
            }
        }


        public static void DebugPrintInstructions() {
            for (int i = 0; i < bets.Length; i++) {
                string print = $"{i + 1})\t${bets[i]}";
                Console.WriteLine(print);
            }
        }

        public void OnNewRound() {
            throw new NotImplementedException();
        }
    }
}
