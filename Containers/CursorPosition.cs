namespace FancyBlackJack.Containers
{
    public struct CursorPosition
    {
        public int top;
        public int left;

        public CursorPosition(int top, int left) {

            this.top = top >= 0 ? top : 0;
            this.left = left >= 0 ? left : 0;
        }


        public static CursorPosition GetCurrentPosition() {
            return new CursorPosition(Console.CursorTop, Console.CursorLeft);
        }
    }
}