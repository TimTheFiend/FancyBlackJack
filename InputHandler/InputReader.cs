using FancyBlackJack.Printing;


namespace FancyBlackJack.InputHandler
{
    public interface IInputReader {
        int ReadPlayerBet(int maxValue, out bool isModified);
    }


    //MOck-frameworks i .net kna bruges til at generere disse klasser for dig.
    public class InputReaderMock : IInputReader {
        public int ReadPlayerBet(int maxValue, out bool isModified) {
            isModified = false;
            return 7;
        }
    }
    public class InputReader : IInputReader
    {
        //NOTE: not in use
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

        /// <summary>
        /// Reads player input, and returns the value of a valid input, alongside with information if <see cref="ConsoleModifiers.Shift"/> has been used.
        /// </summary>
        /// <param name="maxValue">Max value of acceptable input.</param>
        /// <param name="isModified">If input was pressed with <see cref="ConsoleModifiers.Shift"/>.</param>
        /// <returns>User's input as an int.</returns>
        public int ReadPlayerBet(int maxValue, out bool isModified) {
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
                //todo enum
                if (userInputKey.Key is ConsoleKey.Enter) {
                    return -1;  // BetManager only continues with positive integers.
                }

                CheckIfQuit(userInput);
            }
        }


        //NOTE: Was made when ReadNumerical was still in use and I didn't want to rewrite the function and mess up ReadNumerical.
        private static void CheckIfQuit(string input) {
            if (input.Length > 1) { 
                return;
            }
            CheckIfQuit(input.ToCharArray()[0]);
        }

        /// <summary>
        /// Quits the application if the player pressed 'Q'.
        /// </summary>
        /// <param name="input"></param>
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
