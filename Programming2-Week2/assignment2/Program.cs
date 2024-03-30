namespace assignment2
{
    internal class Program
    {
        const int MinimunNumber = 1;
        const int MaximumNumber = 99;
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
            int[,] matrix = new int[numberOfRows, numberOfColumns];
            InitMatrixRandom(matrix, MinimunNumber, MaximumNumber);
            DisplayMatrix(matrix);

            Console.WriteLine("Enter a number (to search for): ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Number {number} is found (first) at position [{SearchNumber(matrix, number).row},{SearchNumber(matrix, number).column}]\n" +
                $"Number {number} is found (last) at position [{SearchNumberBackwards(matrix, number).row},{SearchNumberBackwards(matrix, number).column}]");
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random random = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = random.Next(MinimunNumber, MaximumNumber + 1);
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(String.Format("{0, 4}", matrix[row, col]));
                }
                Console.WriteLine();
            }
        }

        Position SearchNumber(int[,] matrix, int number)
        {
            Position firstPosition = new Position();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(number == matrix[row, col])
                    {
                        firstPosition.row = row;
                        firstPosition.column = col;
                        return firstPosition;
                    }
                    
                }
            }
            return firstPosition;
        }

        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position lastPosition = new Position();

            for (int row = matrix.GetLength(0) - 1; row > 0; row--)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    if (number == matrix[row, col])
                    {
                        lastPosition.row = row;
                        lastPosition.column = col;
                        return lastPosition;
                    }
                }
            }
            return lastPosition;
        }
    }
}