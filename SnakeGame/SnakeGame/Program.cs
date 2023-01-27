namespace SnakeGame
{
    class Program
    {
        public static void SecondThread()
        {
            var currentFood = Field.GenerateFood();

            while(true)
            {
                var intersectFlag = currentFood.CheckIntersection(Snake.Head);

                if (intersectFlag)
                {
                    Field.UpdateProgress();
                    currentFood = Field.GenerateFood();
                    Snake.Speed--;
                }
                Snake.Moove(intersectFlag);
                if (Snake.CheckBordersIntersect() || Snake.CheckBodyIntersect())
                {
                    currentFood.Off();
                    break;
                }

                Thread.Sleep(Snake.Speed);
            }
        }
        static void Main()
        {
            Field.CreateStartState();

            ConsoleKeyInfo turn = new ConsoleKeyInfo();

            Thread secondThread = new Thread(SecondThread);
            secondThread.Start();

            while (true)
            {
                turn = Console.ReadKey();

                switch (turn.Key)
                {
                    case ConsoleKey.RightArrow when Snake.Trend != Direction.Left:
                        Snake.Trend = Direction.Right;
                        break;
                    case ConsoleKey.LeftArrow when Snake.Trend != Direction.Right:
                        Snake.Trend = Direction.Left;
                        break;
                    case ConsoleKey.UpArrow when Snake.Trend != Direction.Down:
                        Snake.Trend = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow when Snake.Trend != Direction.Up:
                        Snake.Trend = Direction.Down;
                        break;
                    case ConsoleKey.M:
                        Snake.Speed += 10;
                        break;
                    case ConsoleKey.P:
                        Snake.Speed -= 10;
                        break;
                }
            }
        }
    }
}