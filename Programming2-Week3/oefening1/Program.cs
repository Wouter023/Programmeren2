namespace oefening1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<char> blacklist = new List<char>();
            for (int i = 0; i < 10; i++)
            {
                char character = ReadChar(blacklist);
                blacklist.Add(character);
            }
            
        }

        char ReadChar(List<char> blacklist)
        {
            char letter;

            do
            {
                Console.Write($"Enter letter: ");
                letter = char.Parse(Console.ReadLine());
            } while (!blacklist.Contains(letter));

            return letter;
        }

        void FillChars()
        {

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
    }
}