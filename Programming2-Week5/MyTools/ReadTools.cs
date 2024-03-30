namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            Console.WriteLine(question);
            return int.Parse(Console.ReadLine());
        }

        public static int ReadInt(string question, int min, int max)
        {
            int value;
            do
            {
                value = ReadInt(question);
            }
            while (value < min || value > max);

            return value;
        }

        public static string ReadString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}