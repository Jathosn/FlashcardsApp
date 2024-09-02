using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Flashcard
{
    internal class Program
    {
        public List<string> Questions { get; private set; } = new List<string>();
        public List<string> Answers { get; private set; } = new List<string>();
        public List<string> Hints { get; private set; } = new List<string>();
        static void Main(string[] args)
        {
            Program program = new Program();

            string textFile = "C:/Users/JanThoresen/source/repos/Flashcard/Flashcard/Info.txt";
            string[] lines = File.ReadAllLines(textFile);
            int totals = lines.Length / 3;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome to the Flashcards app, here to help you ace your next exam! There are currently '{totals}' questions in total \n");
            Console.ResetColor();
            Console.WriteLine($"The questions and answers can be configured in Info.txt. \n\n");

            program.Information(textFile, lines);
            program.Randomizer();

            Console.ReadLine();

        }
         void Information(string textFile, string[] lines)
        {

            for (int i = 0; i < lines.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    Answers.Add(lines[i]);
                }
                else if ((i + 1) % 3 == 1)
                {
                    Questions.Add(lines[i]);
                }
                else
                {
                    Hints.Add(lines[i]);
                }
            }
           // Console.WriteLine(string.Join(Environment.NewLine, Questions));
        }
        public void Randomizer()
        {
            int correctAnswers = 0;
            int wrongAnswers = 0;
            int hintsCounter = 0;
            int counter = 1;
            Random rng = new Random();
            bool continueAsking = true;
            while (continueAsking)
            {
                int n = Questions.Count;
                if (n > 0)
                {
                    int randomIndex = rng.Next(n);
                    Console.WriteLine($"{counter}. {Questions[randomIndex]} Press 'H' for hint. \n");

                    ConsoleKeyInfo hint = Console.ReadKey(true);
                    if (hint.Key == ConsoleKey.H)
                    {
                        Console.WriteLine($"{Hints[randomIndex]} \n");
                        hintsCounter++;
                    }

                    string answer = Console.ReadLine().ToLower();
                    if (answer == Answers[randomIndex].ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThat is correct!\n");
                        Console.ResetColor();
                        correctAnswers++;
                        counter++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThat is incorrect.\n");
                        Console.ResetColor();
                        wrongAnswers++;
                        counter++;
                    }

                    Questions.RemoveAt(randomIndex);
                    Answers.RemoveAt(randomIndex);
                    Hints.RemoveAt(randomIndex);

                    Console.WriteLine($"More questions? Press (y) to continue or any other key to exit. \n");
                    ConsoleKeyInfo continueKey = Console.ReadKey(true);
                    if (continueKey.Key != ConsoleKey.Y)
                    {
                        continueAsking = false;
                    }
                }
                else
                {
                    Console.WriteLine("Looks like you've gone through all your questions. Good job!\n");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"You answered {correctAnswers} out of {correctAnswers + wrongAnswers} correctly.");
                    Console.WriteLine($"You asked for a hint on {hintsCounter} of {correctAnswers + wrongAnswers} questions.");
                    Console.ResetColor();

                    continueAsking = false;
                }
            }
        }
    }
}
