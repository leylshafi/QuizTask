using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTask.Models
{
    internal class Quiz
    {
        private static int _count = 0;
        public Quiz( string name)
        {
            Id = ++_count;
            Name = name;
            Questions = new();
        }

        public int Id { get; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public override string ToString()
        {
            return $"{Id}  |  {Name}";
        }
    }
}
