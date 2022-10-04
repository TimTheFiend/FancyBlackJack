using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyBlackJack.Printing
{
    public static class UIHandler
    {
        public static ConsoleColor Color {
            get {
                return Console.ForegroundColor;
            }
            set {
                Console.ForegroundColor = value; 
            }
        }


        public static int CursorLeft {
            get {
                return Console.CursorLeft;
            }
            set {
                if (value < 0) value = 0;
                Console.CursorLeft = value;
            }
        }

        public static int CursorTop {
            get {
                return Console.CursorTop;
            }
            set {
                if (value < 0) value = 0;
                Console.CursorTop = value;
            }
        }

        public static void ResetCursor() {
            Console.SetCursorPosition(0, 0);
        }
    }
}
