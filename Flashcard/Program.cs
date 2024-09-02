using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Flashcard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textFile = "C:/Users/JanThoresen/source/repos/Flashcard/Flashcard/Questions.txt";
            string[] lines = File.ReadAllLines(textFile);
            int totals = lines.Length / 3;
            Console.WriteLine($"So... you wish to memorize for a test? Please specify the number of questions to choose from. There are {totals} questions in total \n");

            Information(textFile, lines);

            Console.ReadLine();
        }
        static void Information(string textFile, string[] lines)
        {
            List<string> questions = new List<string>();
            List<string> answers = new List<string>();
            List<string> hints = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    answers.Add(lines[i]);
                }
                else if ((i + 1) % 3 == 1)
                {
                    questions.Add(lines[i]);
                }
                else
                {
                    hints.Add(lines[i]);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, questions));
        }
    }
}
