using FancyBlackJack.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.InputHandler
{
    public static class InputReader
    {
        public static char ReadInput() {
            return ReadText(new char[] { 'a', 'b', 'c', 'd' });
        }

        public static char ReadText(params char[] validInputs) {
            while (true) {
                char userInput = Console.ReadKey(true).KeyChar;

                if (validInputs.Contains(userInput)) {
                    return userInput;
                }

                CheckIfQuit(userInput);
            }
        }


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

        //public static int ReadNumerical(int maxValue, out bool hasShiftModifier) {
            //while (true) {
            //    char userInput = Console.ReadKey(true).KeyChar;

            //    if (int.TryParse(userInput.ToString(), out int inputResult)) {
            //        if (inputResult > 0 && inputResult <= maxValue) {
            //            return inputResult;
            //        }
            //    }

            //    CheckIfQuit(userInput);
            //}
        //}


        public static void ModifierTest() {
            while (true) {
                var userInput = Console.ReadKey(true);


                Console.WriteLine(userInput.KeyChar);
                Console.WriteLine(userInput.Key);
                if (userInput.Modifiers == ConsoleModifiers.Shift) {
                    Console.WriteLine(userInput.Modifiers.ToString());
                }
            }
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
