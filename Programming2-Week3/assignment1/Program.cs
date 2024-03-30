namespace assignment1
{
    internal class Program
    {
        const int numberOfCourses = 3;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<Course> gradelist = ReadGradeList(numberOfCourses);
            DisplayGradeList(gradelist);
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
    
        PracticalGrade ReadPracticalGrade(string question)
        {
            PracticalGrade practicalGrade = new PracticalGrade();
            int givenNumber;
            do
            {
                givenNumber = ReadInt(question);
            } while (!Enum.IsDefined(typeof(PracticalGrade), practicalGrade));
            
            return (PracticalGrade)givenNumber;
        }

        void DisplayPracticalGrade(PracticalGrade practical)
        {
            Console.WriteLine(practical.ToString());
        }

        Course ReadCourse(string question)
        {
            Course course = new Course();

            Console.WriteLine($"Enter a course");
            course.Name = ReadString($"Name of the course: ");
            
            Console.WriteLine($"Theory grade of {course.Name}: ");
            course.TheoryGrade = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"0. None 1. Absent 2. Insufficent 3. Sufficient 4. Good");
            course.PracticalGrade = ReadPracticalGrade($"Practical grade for {course.Name}: ");

            course.Passed();
            course.Cumlaude();

            return course;
        }

        void DisplayCourse(Course course)
        {
            Console.WriteLine($"{course.Name}:{course.TheoryGrade}{course.PracticalGrade}");
        }

        List<Course> ReadGradeList(int nrOfcourses)
        {
            List<Course> courseList = new List<Course>();
            for (int i = 1; i <= nrOfcourses; i++)
            {
                courseList.Add(ReadCourse($""));
            }
            return courseList;
        }

        void DisplayGradeList(List<Course> gradelist)
        {
            int countCum = 0;
            int countPas = 0;
            string output = "";
            for (int i = 0; i < gradelist.Count; i++)
            {
                output += String.Format("{0,-20}: {1,-10} {2,-10}\n", gradelist[i].Name, gradelist[i].TheoryGrade, gradelist[i].PracticalGrade);
                if(gradelist[i].Cumlaude() == true)
                {
                    countCum++;
                }
                if (gradelist[i].Passed() == true)
                {
                    countPas++;
                }
            }

            if(countPas < gradelist.Count)
            {
                output += $"Too bad, you did not graduate, you got {gradelist.Count - countPas} retakes";
            }
            else if(countPas == gradelist.Count && countCum < gradelist.Count)
            {
                output += $"Congratulations, you graduated!";
            }
            else
            {
                output += $"Congratulations, you graduated Cum Laude!";
            }

            Console.WriteLine(output);
        }
    }
}