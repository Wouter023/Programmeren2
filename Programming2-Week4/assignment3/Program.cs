namespace assignment3
{
    internal class Program
    {
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
            Console.WriteLine($"Enter a word (to search): ");
            string input = Console.ReadLine().ToLower();
            int numberOfTimes = SearchWordInFile(filename, input);
            Console.WriteLine($"Number of lines containing the word: {numberOfTimes}");
        }

        bool WordInLine(string line, string word)
        {
            if(line.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int SearchWordInFile(string filename, string word)
        {
            StreamReader reader = new StreamReader(filename);
            int counter = 0;

            while (!reader.EndOfStream)
            {
                string s = reader.ReadLine();
                if(WordInLine(s, word))
                {
                    DisplayWordInLine(s, word);
                    counter++;
                }
            }

            reader.Close();
            return counter;
        }

        void DisplayWordInLine(string line, string word)
        {
            int startIndex = line.IndexOf(word);
            string searchWord = line.Substring(startIndex, word.Length);
            string wordReplace = $"[{word}]";
            string newString = line.Replace(word, wordReplace);
            for (int i = 0; i < line.Length + 2; i++)
            {
                if (i >= startIndex && i <= searchWord.Length + startIndex + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(newString[i]);
            }

            Console.WriteLine();
        }
    }
}