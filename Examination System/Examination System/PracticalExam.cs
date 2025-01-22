using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions)
        {
        }

        public override void Show()
        {
            int resultMarks = 0, totalMarks = 0, answer = 0;

            foreach (Question question in questions)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{question.Header}       Mark({question.Mark})");
                Console.WriteLine(question.Body);
                for (int i = 0; i < question.answers.Length; i++)
                {
                    if (question.answers[i] == null) break;
                    Console.Write($"{i + 1}) {question.answers[i]}          ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");

                do
                {
                    Console.Write("->");
                } while (!int.TryParse(Console.ReadLine(), out answer) || answer <= 0 || answer >= 3);

                if (answer == question.CorrectAnswer)
                {
                    resultMarks += question.Mark;
                }
                totalMarks += question.Mark;
            }

            //Practical Exam Shows the right answer after finishing the Exam.
            Console.Clear();
            int num = 1;
            Console.WriteLine("The Right Answer:");
            foreach (Question question in questions)
            {
                Console.WriteLine($"Q{num}) {question.Body} : {question.answers[question.CorrectAnswer - 1].Text}");
                num++;
            }
            Console.WriteLine($"Your Exam Grade Is {resultMarks} Outof {totalMarks}");

        }
    }
}
