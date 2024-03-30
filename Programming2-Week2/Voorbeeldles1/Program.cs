namespace Voorbeeldles1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }
        void Start()
        {
            char[,] playingBoard = new char[3, 3];
            EmptyBoard(playingBoard);
            DrawBoard(playingBoard);
            PlayTicTacToe(playingBoard);
        }
        private void PlayTicTacToe(char[,] board)
        {
            bool playing = true;
            char charToWrite;
            int turn = 1;
            while (playing)
            {
                charToWrite = DeterminePlayer(turn);
                Console.Write($"Row to place {charToWrite}: ");
                // -1 because of the 0 based index
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write($"Column to place {charToWrite}: ");
                // -1 because of the 0 based index
                int col = int.Parse(Console.ReadLine()) - 1;
                if (board[row, col] != ' ')
                {
                    Console.WriteLine($"This is already occupied by an{board[row, col]}");
                    DrawBoard(board);
                    continue;
                }
                board[row, col] = charToWrite;
                DrawBoard(board);
                turn++;
            }
        }
        private void EmptyBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        private void DrawBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write($"{board[row,col]}");
                    if (col < board.GetLength(0) - 1)
                    {
                        Console.Write("|");
                    }
                }
                if(row < board.GetLength(1) - 1) { 
                    Console.WriteLine();
                    Console.WriteLine("-----");
                }
            }
        }
        char DeterminePlayer(int turn)
        {
            char playerChar = ' ';
            if(turn % 2 = 0)
            {

            }
        }
    }
}