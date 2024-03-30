using System.Drawing;

namespace assignment1
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
            int[,] matrix = new int[numberOfRows, numberOfColumns];
            InitMatrixLinear(matrix);
            DisplayMatrixWithCross(matrix);
        }

        void InitMatrix2D(int[,] matrix)
        {
            int element = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = element;
                    element++;
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        void InitMatrixLinear(int[,] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i / matrix.GetLength(0),i % matrix.GetLength(0)] = i + 1;
            }
        }

        void DisplayMatrixWithCross(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int sumRowCol = row + col;
                    if(row == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if(sumRowCol == matrix.GetLength(1) - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(String.Format("{0, 5}", matrix[row, col]));
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}