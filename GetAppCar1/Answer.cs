using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAppCar1
{
    public class Answer
    {
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public int IdNextQuestion { get; set; }
        public string AnswerText { get; set; }
        public string Parameter { get; set; }

        public Answer(int id, int idQuestion, int idNextQuestion, string answerText, string parameter)
        {
            Id = id;
            IdQuestion = idQuestion;
            IdNextQuestion = idNextQuestion;
            AnswerText = answerText;
            Parameter = parameter;
        }
    }
}
