namespace assignment1
{
    internal class Program
    {
        const string filePath = "..\\..\\..\\";
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            string input = ReadString($"Enter your name: ");
            string file = $"{filePath}{input}.txt";

            if (File.Exists(file))
            {
                StreamReader reader = new StreamReader(file);

                Console.WriteLine($"Nice to see you again, {input}!\nWe have the following information about you:");
                DisplayPerson(ReadPerson($"{file}"));

                reader.Close();
            }
            else
            {
                Console.WriteLine($"Welcome {input}!");
                WritePerson(ReadPerson(), $"{input}.txt");
                Console.WriteLine($"Your data is written to file.");
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
            Console.Write(question);
            return Console.ReadLine();
        }
    
        Person ReadPerson()
        {
            Person person = new Person();
            Console.Write("Name\t: ");
            person.name = Console.ReadLine();
            Console.Write("City\t: ");
            person.city = Console.ReadLine();
            Console.Write("Age\t: ");
            person.age = int.Parse(Console.ReadLine());
            return person;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine($"Name\t: {p.name}\nCity\t: {p.city}\nAge\t: {p.age}");
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter writer = File.CreateText($"{filePath}{filename}");

            writer.Write($"{p.name}\n{p.city}\n{p.age}");

            writer.Close();
        }

        Person ReadPerson(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            Person person = new Person();
            person.name = reader.ReadLine();
            person.city = reader.ReadLine();
            person.age = int.Parse(reader.ReadLine());

            reader.Close();

            return person;
        }
    }
}