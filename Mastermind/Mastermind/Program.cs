using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var answerstring = random.Next(1, 6).ToString() + 
                random.Next(1, 6).ToString() +
                random.Next(1, 6).ToString() +
                random.Next(1, 6).ToString();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Your Guess!");
                var guess = Console.ReadLine();
                var guessint = -1;
                while(guess.Length != 4 || !int.TryParse(guess, out guessint))
                {
                    Console.WriteLine("Invalid guess entered! Try again. Guess must be only 4 characters long and contain only numeric values.");
                    guess = Console.ReadLine();
                }
                if (guess == answerstring)
                {
                    Console.WriteLine("Congratulations! The correct answer was " + answerstring + "!");
                    Console.ReadKey();
                } else
                {
                    if (i == 9)
                    {
                        Console.WriteLine("Wrong. You have run out of guesses!");
                        break;
                    }
                    Console.WriteLine("Wrong! Here is your hint. You have used " + (i + 1) + " guesses.");
                    Console.WriteLine(AnswerChecker.GenerateHint(guess, answerstring));

                }
            }
            Console.ReadKey();
        }

        public static class AnswerChecker
        {
            public static string GenerateHint(string guess, string answer)
            {
                var plusses = "";
                var minuses = "";
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                    {
                        plusses += "+";
                    } else if (answer.Contains(guess[i]))
                    {
                        minuses += "-";
                    }
                }
                return plusses + minuses;
            }

        }
    }
}
