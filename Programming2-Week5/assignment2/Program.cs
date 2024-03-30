using CandyCrushLogic;

namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nr of rows> <nr of columns>");
                return;
            }
            int numberOfRows = int.Parse(args[0]);
            int numberOfColumns = int.Parse(args[1]);
            Program myProgram = new Program();
            myProgram.Start(numberOfRows, numberOfColumns);
        }
        void Start(int numberOfRows, int numberOfColumns)
        {
            RegularCandies[,] playingField = new RegularCandies[numberOfRows, numberOfColumns];

            InitCandies(playingField);
            DisplayCandies(playingField);
            CandyCrusher.ScoreColPresent(playingField);

            if (CandyCrusher.ScoreRowPresent(playingField) == true)
            {
                Console.WriteLine($"row score");
            }
            else
            {
                Console.WriteLine($"no row score");
            }

            if (CandyCrusher.ScoreColPresent(playingField) == true)
            {
                Console.WriteLine($"column score");
            }
            else
            {
                Console.WriteLine($"no column score");
            }
        }

        void InitCandies(RegularCandies[,] playingField)
        {
            Random random = new Random();
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    playingField[row, col] = (RegularCandies)random.Next(0, 6);
                }
            }
        }

        void DisplayCandies(RegularCandies[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row, col] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (playingField[row, col] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (playingField[row, col] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (playingField[row, col] == RegularCandies.GumSquare)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (playingField[row, col] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (playingField[row, col] == RegularCandies.JujubeCluster)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write($"# ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}