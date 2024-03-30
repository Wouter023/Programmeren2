namespace assignment2
{
    internal class Program
    {
        const int MaximunAttempts = 8;
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
            HangmanGame hangman = new HangmanGame();
            hangman.Init(SelectWord(ListOfWords(filename)));

            if (PlayHangman(hangman) == true)
            {
                Console.WriteLine($"you guessed the word");
            }
            else
            {
                Console.WriteLine($"Too bad, you did not guess the word ({hangman.secretWord})");
            }
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

        List<string> ListOfWords(string filename)
        {
            List<string> words = new List<string>();
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if(line.Length >= 3)
                {
                    words.Add(line);
                }        
            }
            reader.Close();
            return words;
        }

        string SelectWord(List<string> words)
        {
            Random random = new Random();
            int wordNumber = random.Next(0, words.Count); 
            return words[wordNumber];
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = MaximunAttempts;
            DisplayWord(hangman.guessedWord);

            do
            {
                Console.Write($"Enter a letter: ");
                char enteredLetter = ReadLetter(enteredLetters);
                enteredLetters.Add(enteredLetter);

                if (hangman.ContainsLetter(enteredLetter) == false)
                {
                    attempts--;
                }

                DisplayLetters(enteredLetters);
                Console.WriteLine();
                hangman.ProcessLetter(enteredLetter);
                Console.WriteLine($"Attempts left:{attempts}");
                DisplayWord(hangman.guessedWord);

                if (hangman.IsGuessed() == true)
                {
                    return true;
                }
            } while (attempts > 0);
            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();
        }

        void DisplayLetters(List<char> blacklistLetters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in blacklistLetters)
            {
                Console.Write($"{c} ");
            }
        }

        char ReadLetter(List<char> blacklistLetters)
        {
            char input;
            do
            {
                input = char.Parse(Console.ReadLine());
            } while (blacklistLetters.Contains(input));
            return input;
        }
    }
}