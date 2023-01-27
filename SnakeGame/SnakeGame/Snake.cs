namespace SnakeGame
{
    public static class Snake
    {
        private const char _value = '@';
        public static Direction Trend = Direction.Right;
        public static int Speed = 100;
        public static (int, int) Head = (3, 1);
        public static (int, int) Tail = (1, 1);
        public static List<(int, int)> Body = new List<(int, int)>
        {
            (1, 1),
            (2, 1),
            (3, 1)
        };
        public static void Moove(bool intersectFlag)
        {
            switch(Trend)
            {
                case Direction.Up:
                    Head.Item2--;
                    break;
                case Direction.Right:
                    Head.Item1++;
                    break;
                case Direction.Down:
                    Head.Item2++;
                    break;
                case Direction.Left:
                    Head.Item1--;
                    break;
            }

            Body.Add(Head);
            if(!intersectFlag)
                Body.RemoveAt(0);

            Console.SetCursorPosition(Head.Item1, Head.Item2);
            Console.Write(_value);
            Console.SetCursorPosition(Tail.Item1, Tail.Item2);
            Console.Write(' ');
            Tail = Body[0];
        }
        public static bool CheckBordersIntersect()
        {
            return !(Math.Abs(Snake.Head.Item1 - 30) < 30) || !(Math.Abs(Snake.Head.Item2 - 13) < 13);
        }
        public static bool CheckBodyIntersect()
        {
            return Body.Count(Head.Equals) == 2;
        }
    }
}