using FancyBlackJack.Character;
using FancyBlackJack.InputHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Game
{
    public class BetManager
    {
        private static readonly int[] bets = new int[] {
            10,
            50,
            100
        };
        private static readonly int lowBet = 10;
        private static readonly int midBet = lowBet * 5;
        private static readonly int highBet = lowBet * 10;

        private IInputReader inputReader;
        //Mocks i Test. 
        //Constructor-injection af afhængigheder(dependencies) i OOP
        public BetManager(IInputReader inputReader) {
            this.inputReader = inputReader;
        }

        public static int CurrentBet { get; private set; } = 0;
            
        public void HandlePlayerBet(Player player) {
            CurrentBet = 0;
#if DEBUG
            DebugPrintInstructions();
#endif

            while (true) {

                int userInput = inputReader.ReadPlayerBet(bets.Count(), out bool isRemovingBet);
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
                    // If bet is bigger than the current betting pool, return betting pool and set it to 0.
                    if (CurrentBet < _bet) {
                        //player.Wallet += CurrentBet;
                        player.AddMoney(CurrentBet);
                        CurrentBet = 0;
#if DEBUG
                        Console.WriteLine($"C<B\twallet:{player.Wallet}\tbet:{CurrentBet}");
#endif
                        continue;

                    }
                    if (CurrentBet >= _bet) {
                        //player.Wallet += _bet;
                        player.AddMoney(CurrentBet);
                        CurrentBet -= _bet;
#if DEBUG
                        Console.WriteLine($"C>=B\twallet:{player.Wallet}\tbet:{CurrentBet}");
#endif
                        continue;
                    }

                }

                if (player.AttemptBet(bets[userInput])) {
                    CurrentBet += bets[userInput];
#if DEBUG
                    Console.WriteLine($"C>B\twallet:{player.Wallet}\tbet:{CurrentBet}");
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
