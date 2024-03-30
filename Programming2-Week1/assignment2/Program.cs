namespace assignment2
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
            Person[] person = new Person[3];
            for (int i = 0; i < person.Length; i++)
            {
                person[i] = ReadPerson();
                Console.WriteLine();
            }
            for (int i = 0; i < person.Length; i++)
            {
                PrintPerson(person[i]);
                Console.WriteLine();
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

        Person ReadPerson()
        {
            Person person = new Person();
            person.FirstName = ReadString("Enter first name: ");
            person.LastName = ReadString("Enter last name: ");
            person.Gender = ReadGender("Enter gender (m/f): ");
            person.Age = ReadInt("Enter age: ");
            person.City = ReadString("Enter city: ");

            return person;
        }

        void PrintPerson(Person p)
        {
            Console.Write($"{p.FirstName} {p.LastName}");
            PrintGender(p.Gender);
            Console.WriteLine($"{p.Age} years old, {p.City}");
        }

        GenderType ReadGender(string question)
        {
            Console.WriteLine(question);
            GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), Console.ReadLine().ToLower());
            return gender;
        }

        void PrintGender(GenderType gender)
        {
            Console.WriteLine($"({gender})");
        }
    }
}