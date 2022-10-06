using FancyBlackJack.Character;
using FancyBlackJack.InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Game
{
    public static class BetManager
    {
        private static readonly int[] bets = new int[] {
            10,
            50,
            100
        };
        private static readonly int lowBet = 10;
        private static readonly int midBet = lowBet * 5;
        private static readonly int highBet = lowBet * 10;


        public static int CurrentBet { get; private set; } = 0;
            
        public static void HandlePlayerBet(Player player) {
            CurrentBet = 0;
#if DEBUG
            DebugPrintInstructions();
#endif

            while (true) {
                int userInput = InputReader.ReadPlayerBet(bets.Count(), out bool isRemovingBet);
                userInput--; // .ReadPlayerBet returns the unedited value. -1 for the accurate bet index.
                //Check if player is done betting.
                if (userInput < 0) {
#if DEBUG
                    Console.WriteLine("BETTING DONE");
#endif
                    return;
                }

                int _bet = bets[userInput];

                if (isRemovingBet) {
                    if (CurrentBet >= _bet) {
                        player.wallet += _bet;
                        CurrentBet -= _bet;
#if DEBUG
                        Console.WriteLine($"wallet:{player.wallet}\tbet:{CurrentBet}");
#endif
                    }

                    continue;
                }

                if (player.AttemptBet(bets[userInput])) {
                    CurrentBet += bets[userInput];
#if DEBUG
                    Console.WriteLine($"wallet:{player.wallet}\tbet:{CurrentBet}");
#endif
                }
            }
        }

        

        public static void DebugPrintInstructions() {
            string[] msgs = new string[] {
                $"1) ${lowBet}",
                $"2) ${midBet}",
                $"3) ${highBet}"
            };

            foreach (string msg in msgs) {
                Console.WriteLine(msg);
            }
        }
    }
}
