using FancyBlackJack.Printing;


namespace FancyBlackJack.InputHandler
{
    public static class InputReader
    {
        public static int ReadNumerical(int maxValue) {
            while (true) {
                char userInput = Console.ReadKey(true).KeyChar;

                if (int.TryParse(userInput.ToString(), out int inputResult)) {
                    if (inputResult > 0 && inputResult <= maxValue) {
                        return inputResult;
                    }
                }

                CheckIfQuit(userInput);
            }
        }

        public static int ReadPlayerBet(int maxValue, out bool isModified) {
            isModified = false;
            while (true) {
                var userInputKey = Console.ReadKey(true);  //Is used to check if 
                string userInput = userInputKey.Key.ToString();

                if (int.TryParse(userInput[1..], out int inputResult)) {
                    if (inputResult > 0 && inputResult <= maxValue) {
                        isModified = userInputKey.Modifiers.HasFlag(ConsoleModifiers.Shift);
                        return inputResult;
                    }
                }
                // If player is done
                if (userInputKey.Key is ConsoleKey.Enter) {
                    return -1;  // BetManager only continues with positive integers.
                }

                CheckIfQuit(userInput);
            }
        }


        private static void CheckIfQuit(string input) {
            if (input.Length > 1) {
                return;
            }
            CheckIfQuit(input.ToCharArray()[0]);
        }

        //TODO
        private static void CheckIfQuit(char input) {
            if (input == 'Q' || input == 'q') {
                Console.Clear();
                UIHandler.ResetCursor();
                Console.WriteLine("EXITING GAME");
                Environment.Exit(0);
            }
        }
    }
}
