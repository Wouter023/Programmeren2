namespace assignment0
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
            int value = ReadInt("Enter a value: ");
            Console.WriteLine($"You entered {value}.");
            int age = ReadInt("How old are you? ", 0, 120);
            Console.WriteLine($"You are {age} years old.");
            string name = ReadString("What is your name? ");
            Console.WriteLine($"Nice meeting you {name}.");
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