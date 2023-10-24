using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTask.Models
{
    internal class Question
    {
        public Question(string questionDesc)
        {
            QuestionDesc = questionDesc;
            Answers = new();
        }

        public string QuestionDesc  { get; set; }
        public List<Answer> Answers  { get; set; }
    }
}
