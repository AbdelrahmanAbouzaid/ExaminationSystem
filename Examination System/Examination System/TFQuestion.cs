using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TFQuestion : Question
    {
        ////Best Practice -> useing Chain Constructor
        //public TFQuestion(string header, string body, int mark)
        //{
        //    Header = header;
        //    Body = body;
        //    Mark = mark;
        //}
        public TFQuestion( string body, int mark)
            :base(body, mark)
        {
            Header = "True | False Qestion";
            answers[0] = new Answer(0,"True");
            answers[1] = new Answer(0,"False");
        }
    }
}
