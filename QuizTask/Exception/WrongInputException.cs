using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTask.Exceptions
{
    internal class WrongInputException:Exception
    {
        public WrongInputException(string message = "Wrong input"):base(message)
        {

        }
    }
}
