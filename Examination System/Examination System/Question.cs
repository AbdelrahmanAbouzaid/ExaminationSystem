using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal abstract class Question   // abstruct : I don't need to crate instance from Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] answers { get; set; }
        public int CorrectAnswer { get; set; }
        public Question(string header, string body, int mark)
            : this(body, mark)
        {
            Header = header;
        }

        public Question(string body, int mark)
        {
            Body = body;
            Mark = mark;
            answers = new Answer[3]; //UnKnown Length - Best Practice Using Dynamic Array Such As [List<Array>]
            
        }
    }
}
