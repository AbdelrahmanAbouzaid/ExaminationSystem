using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private void CreateExamInstance(out int time, out int noQuestions)
        {
            do
            {
                Console.Write("Enter the Time Of Exam In Minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);
            do
            {
                Console.Write("Enter the Number Of Questions You Want To Create: ");
            } while (!int.TryParse(Console.ReadLine(), out noQuestions) || noQuestions <= 0);
        }
        private void CreateQuestionInstance(out string body, out int mark)
        {
            do
            {
                Console.WriteLine("Enter The Body Of Question:");

            } while ((body = Console.ReadLine()) == null);
            do
            {
                Console.Write($"Enter the Mark Of Question: ");
            } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

        }
        public void CreateExam()
        {
            int number, time, noQuestions;
            string body;
            int mark, correctAnswer;
            do
            {
                Console.Write("Enter the Type Of Exam You Want To Create(1. Final Exam | 2. Practical Exam): ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number >= 3);

            if (number == 1)
            {
                // <<! DRY >>
                //do
                //{
                //    Console.Write("Enter the Time Of Exam In Minutes: ");
                //} while (!int.TryParse(Console.ReadLine(), out time) || time <= 0);
                //do
                //{
                //    Console.Write("Enter the Number Of Questions You Want To Create: ");
                //} while (!int.TryParse(Console.ReadLine(), out noQuestions) || noQuestions <= 0);
                CreateExamInstance(out time, out noQuestions);
                Exam = new FinalExam(time, noQuestions);
                for (int i = 0; i < noQuestions; i++)
                {
                    int choise;
                    do
                    {
                        Console.Write($"Choose the Type Of Question({i + 1}) (1. True Or False || 2. MCQ): ");
                    } while (!int.TryParse(Console.ReadLine(), out choise) || choise <= 0 || choise >= 3);

                    if (choise == 1)
                    {
                        CreateQuestionInstance(out body, out mark);
                        Exam.questions[i] = new TFQuestion(body, mark);
                        do
                        {
                            Console.Write($"Choose the Correct Answer(1.True | 2.False): ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer <= 0 || correctAnswer >= 3);
                        Exam.questions[i].CorrectAnswer = correctAnswer;
                    }
                    else
                    {
                        CreateQuestionInstance(out body, out mark);
                        Exam.questions[i] = new MCQQuestion(body, mark);
                        Console.WriteLine("Enter The Choises Of Qestion:");
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write($"Enter The Choise Number({j + 1}): ");
                            string answer = Console.ReadLine();
                            Exam.questions[i].answers[j] = new Answer(j, answer);
                        }
                        do
                        {
                            Console.Write($"Choose the Correct Answer: ");
                        } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer <= 0 || correctAnswer >= 4);
                        Exam.questions[i].CorrectAnswer = correctAnswer;
                    }
                }
            }
            else
            {
                CreateExamInstance(out time, out noQuestions);
                Exam = new PracticalExam(time, noQuestions);
                for (int i = 0; i < noQuestions; i++)
                {
                    Console.WriteLine("True | False Question");
                    CreateQuestionInstance(out body, out mark);
                    Exam.questions[i] = new TFQuestion(body, mark);
                    do
                    {
                        Console.Write($"Choose the Correct Answer(1.True | 2.False): ");
                    } while (!int.TryParse(Console.ReadLine(), out correctAnswer) || correctAnswer <= 0 || correctAnswer >= 3);
                    Exam.questions[i].CorrectAnswer = correctAnswer;
                }
            }
            

            




        }
    }
}
