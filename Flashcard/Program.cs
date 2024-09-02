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

            string textFile = "C:/Users/JanThoresen/source/repos/Flashcard/Flashcard/Questions.txt";
            string[] lines = File.ReadAllLines(textFile);
            int totals = lines.Length / 3;
            Console.WriteLine($"Practicing for a test, are we? Please specify the number of questions to choose from. There are '{totals}' questions in total \n");

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
            Random rng = new Random();
            bool continueAsking = true;
            while (continueAsking)
            {
                int n = Questions.Count;
                if (n > 0)
                {
                    int randomIndex = rng.Next(n);
                    Console.WriteLine($"Random Question: {Questions[randomIndex]}");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == Answers[randomIndex].ToLower())
                    {
                        Console.WriteLine("That is correct!");
                    }
                    else
                    {
                        Console.WriteLine("That is incorrect.");
                    }

                    Questions.RemoveAt(randomIndex);
                    Answers.RemoveAt(randomIndex);
                    Hints.RemoveAt(randomIndex);

                    Console.WriteLine("More questions? Press (y) to continue or any other key to exit.");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput != "y")
                    {
                        continueAsking = false;
                    }
                }
                else
                {
                    Console.WriteLine("No more questions available.");
                    continueAsking = false;
                }
            }
        }
    }
}
