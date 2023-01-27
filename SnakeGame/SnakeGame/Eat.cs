namespace SnakeGame
{
    public class Eat
    {
        private const char _value = '$';
        private (int, int) coords;
        public Eat(int x, int y)
        {
            coords.Item1 = x;
            coords.Item2 = y;
        }
        public void  On()
        {
            var currentCursorPosition = Console.GetCursorPosition();

            Console.SetCursorPosition(coords.Item1, coords.Item2);
            Console.Write(_value);
        }
        public void Off()
        {
            var currentCursorPosition = Console.GetCursorPosition();

            Console.SetCursorPosition(coords.Item1, coords.Item2);
            Console.Write(' ');
            Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
        }
        public bool CheckIntersection((int, int) head)
        {
            if (coords == head)
                return true;
            return false;
        }
    }
}