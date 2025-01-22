using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions)
        {
        }
        public override void Show()
        {
            int totalMarks = 0, resultMarks = 0;
            int counter = 0;
            int[] answers = new int[NomberOfQuestions];
            foreach (Question question in questions)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{question.Header}       Mark({question.Mark})");
                Console.WriteLine(question.Body);
                for (int i = 0; i < question.answers.Length; i++)
                {
                    if (question.answers[i] == null) break;
                    Console.Write($"{i + 1}. {question.answers[i]}          ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------------");
                if (question.GetType().Name == "TFQuestion")
                {
                    do
                    {
                        Console.Write("->");
                    } while (!int.TryParse(Console.ReadLine(), out answers[counter]) || answers[counter] <= 0 || answers[counter] >= 3);
                }
                else
                {
                    do
                    {
                        Console.Write("->");
                    } while (!int.TryParse(Console.ReadLine(), out answers[counter]) || answers[counter] <= 0 || answers[counter] >= 4);
                }
                if (answers[counter] == question.CorrectAnswer)
                {
                    resultMarks += question.Mark;
                }
                totalMarks += question.Mark;
                counter++;
            }
            //Final Exam Shows the Questions, Answers and Grade.
            Console.Clear();
            int num = 1;
            Console.WriteLine("Your Answers:");
            foreach (Question question in questions)
            {
                Console.WriteLine($"Q{num}) {question.Body} : {question.answers[counter - 1].Text}");
                num++;
            }
            Console.WriteLine($"Your Exam Grade Is {resultMarks} Outof {totalMarks}");
        }
    }
}
