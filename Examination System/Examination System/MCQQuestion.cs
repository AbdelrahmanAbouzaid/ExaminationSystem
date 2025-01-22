using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MCQQuestion : Question
    {
        ////Best Practice -> useing Chain Constructor
        //public MCQQuestion(string header, string body, int mark)
        //{
        //    Header = header;
        //    Body = body;
        //    Mark = mark;
        //}
        public MCQQuestion(string body, int mark)
            : base(body, mark)
        {
            Header = "Choose The Correct Answer";
        }
    }
}
