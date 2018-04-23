using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropyCalculator
{
    class Program
    {
        /// <summary>
        /// Reads a file as lines, returning it as an array of strings.
        /// </summary>
        /// <param name="filename">The filename of the file to read.</param>
        /// <returns></returns>
        public static string[] ReadFileAsLines(string filename)
        {
            return File.ReadAllText(filename)
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        static void Main(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Couldn't find input file.");
                return;
            }

            // Read in file.
            var input = ReadFileAsLines(args[0]);

            // Decide on mode.
            var mode = EntropyMode.LudsClasses;
            if (args.Length == 2 && args[1] == "-d")
            {
                mode = EntropyMode.DistinctCharacter;
            }
            var calculator = ScoreCalculatorFactory.GetScoreCalculator(mode);

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]}:{calculator.CalculateScore(input[i])}");
            }
        }
    }
}
