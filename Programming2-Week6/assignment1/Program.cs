using System.Diagnostics.CodeAnalysis;

namespace assignment1
{
    internal class Program
    {
        const int BoardLength = 8;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            ChessPiece[,] chessboard = new ChessPiece[BoardLength,BoardLength];
            InitChessboard(chessboard);
            DisplayChessboard(chessboard);
            PlayChess(chessboard);
        }

        int ReadInt(string question)
        {
            Console.WriteLine(question);
            return int.Parse(Console.ReadLine());
        }

        int ReadInt(string question, int min, int max)
        {
            int value;
            do
            {
                value = ReadInt(question);
            }
            while (value < min || value > max);

            return value;
        }

        string ReadString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    
        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < BoardLength; i++)
            {
                for (int j = 0; j < BoardLength; j++)
                {
                    chessboard[i, j] = null;
                }
            }
            PutChessPieces(chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < BoardLength; i++)
            {
                Console.Write($"{BoardLength - i} ");
                for (int j = 0; j < BoardLength; j++)
                {
                    if(((i + j) % 2) == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    
                    DisplayChessPieces(chessboard[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine($"   a  b  c  d  e  f  g  h");
        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = {ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.Queen, ChessPieceType.King, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook};

            for (int i = 0; i < BoardLength; i++)
            {
                for (int j = 0; j < BoardLength; j++)
                {
                    chessboard[i, j] = new ChessPiece();
                    if(i == 0)
                    {   
                        chessboard[i, j].type = order[j];
                        chessboard[i, j].color = ChessPieceColor.Black;
                    }
                    else if(i == 1)
                    {
                        chessboard[i, j].type = ChessPieceType.Pawn;
                        chessboard[i, j].color = ChessPieceColor.Black;
                    }
                    else if(i == 6)
                    {
                        chessboard[i, j].type = ChessPieceType.Pawn;
                        chessboard[i, j].color = ChessPieceColor.White;
                    }
                    else if(i == 7)
                    {
                        chessboard[i, j].type = order[j];
                        chessboard[i, j].color = ChessPieceColor.White;
                    }
                    else
                    {
                        chessboard[i, j] = null;
                    }
                }
            }
        }

        void DisplayChessPieces(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write($"   ");
            }
            else
            {
                if (chessPiece.color == ChessPieceColor.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    char letter = chessPiece.type.ToString()[0];
                    if (chessPiece.type == ChessPieceType.King || chessPiece.type == ChessPieceType.Queen)
                    {
                        Console.Write($" {letter} ");
                    }
                    else
                    {
                        string lowerLetter = letter.ToString().ToLower();
                        Console.Write($" {lowerLetter} ");
                    }
                }
                else if (chessPiece.color == ChessPieceColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    char letter = chessPiece.type.ToString()[0];
                    if (chessPiece.type == ChessPieceType.King || chessPiece.type == ChessPieceType.Queen)
                    {
                        Console.Write($" {letter} ");
                    }
                    else
                    {
                        string lowerLetter = letter.ToString().ToLower();
                        Console.Write($" {lowerLetter} ");
                    }
                }
            }
            Console.ResetColor();
        }

        Position String2Position(string pos)
        {
            int column = pos[0] - 'a';
            int row = 8 - int.Parse(pos[1].ToString());
            
            if(column < 0 || column > 7 || row < 0 || row > 7)
            {
                throw new Exception($"invalid position: {pos[0]}{pos[1]}");
            }
            Position position = new Position();
            position.row = row;
            position.column = column;
            return position;
        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            string input = "";
            do
            {
                Console.WriteLine($"Enter move (e.g. a2 a3):");
                input = Console.ReadLine();
                
                if(input != "stop")
                {
                    string[] strings = input.Split(' ');
                    try
                    {
                        Position firstPosition = String2Position(strings[0]);
                        Position secondPosition = String2Position(strings[1]);
                        Console.WriteLine($"move from {strings[0]} to {strings[1]}");
                        DoMove(chessboard, firstPosition, secondPosition);
                        DisplayChessboard(chessboard);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }
                    
                }
                
            } while (input != "stop");
        }

        void DoMove(ChessPiece[,] chessboard, Position from, Position to){
            try
            {
                CheckMove(chessboard, from, to);
                chessboard[to.row, to.column] = chessboard[from.row, from.column];
                chessboard[from.row, from.column] = null;
            }
            catch(Exception a)
            {
                Console.WriteLine($"{a.Message}");
            }
        }

        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            if(chessboard[from.row, from.column] == null)
            {
                throw new Exception($"No chess piece at from-position");
            }
            if (chessboard[to.row, to.column] != null && chessboard[from.row, from.column].color == chessboard[to.row, to.column].color)
            {
                throw new Exception($"Can not take a chess piece of same color");
            }
            int ver = Math.Abs(to.row - from.row);
            int hor = Math.Abs(to.column - from.column);
            switch(chessboard[from.row, from.column].type)
            {
                case ChessPieceType.Rook:
                    if(!(hor * ver == 0))
                    {
                        throw new Exception($"Invalid move for chess piece Rook");
                    }
                    break;
                case ChessPieceType.Knight:
                    if (!(hor * ver == 2))
                    {
                        throw new Exception($"Invalid move for chess piece Knight");
                    }
                    break;
                case ChessPieceType.Bishop:
                    if (!(hor == ver))
                    {
                        throw new Exception($"Invalid move for chess piece Bishop");
                    }
                    break;
                case ChessPieceType.King:
                    if (!((hor == 1) || (ver == 1)))
                    {
                        throw new Exception($"Invalid move for chess piece King");
                    }
                    break;
                case ChessPieceType.Queen:
                    if (!((hor * ver == 0) || (hor == ver)))
                    {
                        throw new Exception($"Invalid move for chess piece Queen");
                    }
                    break;
                case ChessPieceType.Pawn:
                    if (!(hor == 0) && (ver == 1))
                    {
                        throw new Exception($"Invalid move for chess piece Pawn");
                    }
                    break;
            }
        }
    }
}