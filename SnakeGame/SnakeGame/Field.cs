namespace SnakeGame
{
    public static class Field
    {
        const int FieldWidth = 60;
        const int FieldHeight = 27;
        private const int CounterX_coord = 62;
        private const int CounterY_coord = 0;
        private static int Counter = 0;

        public static void CreateStartState()
        {
            Console.CursorVisible = false;
            CreateBorders();
            UpdateProgress();
            Console.SetCursorPosition(1, 1);
            Console.Write("@@@");
        }
        private static void CreateBorders()
        {
            for (int i = 0; i < FieldWidth + 1; i++)
                Console.Write('#');
            Console.WriteLine();

            for (int i = 0; i < FieldHeight - 2; i++)
            {
                Console.WriteLine("#                                                           #");
            }

            for (int i = 0; i < FieldWidth + 1; i++)
                Console.Write('#');
        }
        public static Eat GenerateFood()
        {
            while (true)
            {
                var rnd = new Random();
                var rndX = rnd.Next(58) + 1;
                var rndY = rnd.Next(23) + 1;
                var coordinatesOfEat = (rndX, rndY);
                if(Snake.Body.Count(coordinatesOfEat.Equals) < 1)
                {
                    var eat = new Eat(rndX, rndY);
                    eat.On();
                    return eat;
                }
            }
        }
        public static void UpdateProgress()
        {
            var currentCursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(CounterX_coord, CounterY_coord);
            Console.Write(Counter);
            Console.SetCursorPosition(currentCursorPosition.Left, currentCursorPosition.Top);
            Counter++;
        }
    }
}