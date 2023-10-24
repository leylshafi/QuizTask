using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTask.Exceptions
{
    internal class QuizNotFoundException:Exception
    {
        public QuizNotFoundException(string message = "Quiz not found"):base(message) { }
        
    }
}
