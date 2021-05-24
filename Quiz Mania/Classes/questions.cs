using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Mania
{
    public class Questions
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<Answer> answers { get; set; }

        public Questions()
        {
            answers = new List<Answer>();
        }
    }

    public class Answer
    {
        public string answer { get; set; }
        public bool status { get; set; }
    }
}
