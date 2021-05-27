using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAppCar1
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }

        public Question(int id, string questionText)
        {
            Id = id;
            QuestionText = questionText;
        }
    }
}
