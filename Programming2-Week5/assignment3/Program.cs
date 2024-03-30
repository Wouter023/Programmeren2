using MyTools;

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
            Dictionary<string, string> data = new Dictionary<string, string>();
            data = ReadWords(filename);
            TranslateWords(data);
        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> words = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(filename);
            string[] splitWords = new string[2];
            //if file exists
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                splitWords = line.Split(';');

                words.Add(splitWords[0], splitWords[1]);
            }
            reader.Close();
            return words;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            bool userInputIsStop = false;
            while (!userInputIsStop)
            {
                string userInput = ReadTools.ReadString("Enter a word: ").ToLower();
                if (userInput == "stop")
                {
                    userInputIsStop = true;
                }
                else
                {
                    if (userInput == "listall")
                    {
                        ListAllWords(words);
                    }
                    else if (!words.ContainsKey(userInput))
                    {
                        Console.WriteLine($"word '{userInput}' not found");
                    }
                    else
                    {
                        Console.WriteLine($"{userInput} => {words[userInput]}");
                    }
                }
            } 
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            foreach (KeyValuePair<string, string> line in words)
            {
                Console.WriteLine($"{line.Key} => {line.Value}");
            }
        }
    }
}