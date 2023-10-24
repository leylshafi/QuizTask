using QuizTask.Exceptions;
using QuizTask.Models;
using System.Text.RegularExpressions;

namespace QuizTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Quiz> quizzes = new();
            Menu(ref quizzes);
        }

        public static void Menu(ref List<Quiz> quizzes)
        {
            Console.Clear();
            Console.WriteLine(@"======= ANA MENYU =======
[1] Create new quiz
[2] Solve a quiz
[3] Show quizzes
[4] Quit
");
            Console.Write(">>> ");
            int.TryParse(Console.ReadLine(), out int choice);
            Choose(choice, ref quizzes);
        }

        public static void Choose(int choice, ref List<Quiz> quizzes)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter quiz name: ");
                    Console.Write(">>> ");
                    try
                    {
                        Question question;
                        Quiz quiz;
                        Answer answer;
                        string name = Console.ReadLine();
                        if (Format(ref name) != "")
                        {
                            quiz = new Quiz(name);
                            Console.WriteLine("Enter the count of questions");
                            int.TryParse(Console.ReadLine(), out int count);
                            if (count != 0)
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    Console.Write(">>> ");
                                    Console.WriteLine($"Enter question number {i + 1} description");
                                    string questionDesc = Console.ReadLine().Trim();
                                    if (!String.IsNullOrEmpty(questionDesc))
                                    {
                                        question = new Question(questionDesc);
                                        Console.WriteLine("Enter variants");
                                        bool check = false;
                                        for (int j = 0; j < 4; j++)
                                        {
                                            Console.Write($"{j + 1}) ");
                                            string variant = Console.ReadLine().Trim();
                                            if (!String.IsNullOrEmpty(variant))
                                            {


                                                if (!check)
                                                {
                                                    Console.WriteLine("Is is correct? y/n");
                                                    Console.Write(">>> ");
                                                    char.TryParse(Console.ReadLine(), out char c);
                                                    if (c == 'y')
                                                    {
                                                        answer = new(variant, true);
                                                        question.Answers.Add(answer);
                                                        check = true;
                                                    }
                                                    else if (c == 'n')
                                                    {
                                                        answer = new(variant, false);
                                                        question.Answers.Add(answer);
                                                    }
                                                    else throw new WrongInputException("Incorrect input");
                                                }
                                                else
                                                {
                                                    answer = new(variant, false);
                                                    question.Answers.Add(answer);
                                                }
                                            }
                                            else throw new WrongInputException("Variant can not be empty");
                                        }
                                        quiz.Questions.Add(question);
                                    }
                                    else throw new WrongInputException("Question can not be empty");
                                }
                                quizzes.Add(quiz);
                                Console.WriteLine("Quiz created successfully");
                            }
                            else throw new WrongInputException("Incorrect input");

                        }
                        else
                        {
                            throw new WrongInputException("Incorrect input");

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Choose(1, ref quizzes);
                    }
                    Console.WriteLine("\n[Press Enter]\n");
                    Console.ReadLine();
                    break;
                case 2:
                    try
                    {
                        if (quizzes.Count > 0)
                        {
                            foreach (var quiz in quizzes)
                            {
                                Console.WriteLine(quiz);
                            }

                            Console.WriteLine("Enter the id of the quiz: ");
                            int.TryParse(Console.ReadLine(), out int id);
                            if (!quizzes.Any(c => c.Id == id))
                            {
                                throw new QuizNotFoundException("There is no such quiz");
                            }
                            else
                            {
                                Quiz quiz = quizzes.Find(c => c.Id == id);
                                for (int i = 0; i < quiz.Questions.Count; i++)
                                {
                                    Console.WriteLine("===========================");
                                    Console.WriteLine(quiz.Questions[i].QuestionDesc);
                                    for (int j = 0; j < quiz.Questions[i].Answers.Count; j++)
                                    {
                                        Console.WriteLine($"{j + 1}) {quiz.Questions[i].Answers[j]}");
                                    }
                                    Console.WriteLine("Enter the answer");
                                    int.TryParse(Console.ReadLine(), out int ans);
                                    if (ans == 0) throw new WrongInputException("Incorrect input");
                                    else
                                    {
                                        Answer answer = quiz.Questions[i].Answers[ans - 1];
                                        if (answer is not null)
                                        {
                                            if (answer.IsCorrect)
                                                Console.WriteLine("Correct");
                                            else Console.WriteLine("Incorrect");
                                        }
                                        else throw new WrongInputException("Incorrect input");

                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new QuizNotFoundException("There is no quiz yet");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("\n[Press Enter]\n");
                    Console.ReadLine();
                    break;
                case 3:
                    try
                    {

                        if (quizzes.Count > 0)
                        {
                            foreach (var quiz in quizzes)
                            {
                                Console.WriteLine(quiz);
                            }
                        }
                        else throw new QuizNotFoundException("There is no quiz yet");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("\n[Press Enter]\n");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Good bye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    Console.WriteLine("\n[Press Enter]\n");
                    Console.ReadLine();
                    Menu(ref quizzes);
                    break;
            }
            Menu(ref quizzes);
        }

        public static string Format(ref string text)
        {
            text = text.Trim();
            char firstLetter = text[0];
            string temp = text.Substring(1).ToLower();
            text = Char.ToUpper(firstLetter) + temp;

            Regex rg = new Regex("^[A-Z][a-z]+(\\s[A-Z]?[a-z]+)*$");
            if (rg.IsMatch(text))
                return text;
            else return string.Empty;
        }

    }
}