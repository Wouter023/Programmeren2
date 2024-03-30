namespace assignment1
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
            PrintMonths();

            PrintMonth(ReadMonth("Enter a number: "));
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

        void PrintMonth(Month month)
        {
            Console.WriteLine($"{(int)month} => {month}");
        }

        void PrintMonths()
        {
            for (Month m = Month.January; m <= Month.December; m++)
            {
                Console.WriteLine(String.Format("{0, 3}. {1, -10}", (int)m, m));
            }

            //foreach (Month month in Enum.GetValues(typeof(Month)))
            //{
            //    Console.Write("0,2 .", (int)month);
            //    PrintMonth(month);
            //}
        }

        Month ReadMonth(string question)
        {
            Month month;
            do
            {
                month = (Month)ReadInt(question);

                if((int)month < 1 || (int)month > 12)
                {
                    Console.WriteLine($"{(int)month} is not a valid value.");
                }
            } while (!Enum.IsDefined(typeof(Month), month));
            return month;
        }
    }
}