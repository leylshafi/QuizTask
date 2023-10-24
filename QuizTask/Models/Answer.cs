using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTask.Models
{
    internal class Answer
    {
        public Answer(string answerDesc,bool isCorrect)
        {
            AnswerDesc = answerDesc;
            IsCorrect= isCorrect;
        }

        public string AnswerDesc { get; set; }
        public bool IsCorrect { get; set; }

        public override string ToString()
        {
            return AnswerDesc;
        }
    }
}
