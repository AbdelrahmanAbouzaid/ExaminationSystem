using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Exam  // abdstruct class to create abstruct method
    {
        public int Time { get; set; }
        public int NomberOfQuestions { get; set; }

        // for multiple Questions or different types[TF,MCQ] using binding
        public Question[] questions { get; set; }

        protected Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NomberOfQuestions = numberOfQuestions;
            questions = new Question[numberOfQuestions];
        }

        //Functionality that its implementations will be different for each exam based on its type
        public abstract void Show(); 

    }
}
