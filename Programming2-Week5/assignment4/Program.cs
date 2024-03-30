using System.Net.Mail;
using MyTools;

namespace assignment4
{
    internal class Program
    {
        const int NumberOfAttempts = 5;
        const int WordLength = 5;
        Random random = new Random();
        string lingoWord = "";
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }
            string filename = args[0];

            Program myProgram = new Program();
            myProgram.Start(filename);
        }

        void Start(string filename)
        {
            lingoWord = SelectWord(ReadWords(filename, WordLength));

            LingoGame lingoGame = new LingoGame();
            lingoGame.Init(lingoWord);
            PlayLingo(lingoGame);
        }

        List<string> ReadWords(string filename, int wordlength)
        {
            List<string> words = new List<string>();
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if(line.Length == wordlength)
                {
                    words.Add(line);
                }
            }
            reader.Close();
            return words;
        }

        string SelectWord(List<string> words)
        {
            return words[random.Next(words.Count - 1)];
        }

        bool PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = NumberOfAttempts;
            int wordLength = lingoGame.lingoWord.Length;

            while(attemptsLeft > 0 && !lingoGame.WordGuessed())
            {
                Console.WriteLine($"Enter a (5-letter) word, attempt {NumberOfAttempts - (attemptsLeft - 1)}:");
                string playerWord = ReadPlayerWord(wordLength);
                LingoGame.LetterState[] letterResults = lingoGame.ProcessWord(playerWord);
                DisplayPlayerWord(playerWord, letterResults);
                Console.WriteLine();
                attemptsLeft--;
            }
            return lingoGame.WordGuessed();
        }

        string ReadPlayerWord(int wordLength)
        {
            string word;
            do
            {
                word = Console.ReadLine().ToUpper();
            } while (word.Length != wordLength);
            return word;
        }

        void DisplayPlayerWord(string playerWord, LingoGame.LetterState[] letterResults)
        {
            for (int i = 0; i < playerWord.Length; i++)
            {
                if (letterResults[i] == LingoGame.LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (letterResults[i] == LingoGame.LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write($"{playerWord[i]}");
                Console.ResetColor();
            }
        }
    }
}