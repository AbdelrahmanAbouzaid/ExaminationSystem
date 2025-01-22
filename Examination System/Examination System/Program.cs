using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();
            Console.Clear();

            Console.WriteLine("Do You Want To Start The Exam (Y | N): ");
            if (char.Parse(Console.ReadLine().ToLower()) == 'y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                subject.Exam.Show();
                Console.WriteLine($"The Elapsed Time : {stopwatch.Elapsed}");
            }

        }
    }
}
