﻿using System;
using System.IO;

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
            // Print help.
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: App <file> [-s|-l|-d|-u]");
                Console.WriteLine("-s: Shannon entropy mode");
                Console.WriteLine("-l: Length-only mode");
                Console.WriteLine("-d: Distinct-character mode");
                Console.WriteLine("-u: LUDS mode");
            }

            // Check input file exists.
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Couldn't find input file.");
                return;
            }

            // Read in file.
            var input = ReadFileAsLines(args[0]);

            // Decide on mode.
            var mode = EntropyMode.Shannon; // Shannon by default.
            if (args.Length == 2)
            {
                switch (args[1])
                {
                    case "-s":
                        mode = EntropyMode.Shannon;
                        break;
                    case "-l":
                        mode = EntropyMode.LengthOnly;
                        break;
                    case "-d":
                        mode = EntropyMode.DistinctCharacter;
                        break;
                    case "-u":
                        mode = EntropyMode.LudsClasses;
                        break;
                }
            }
            var calculator = ScoreCalculatorFactory.GetScoreCalculator(mode);

            // Process input.
            Console.WriteLine($"password, score");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]}, {calculator.CalculateScore(input[i])}");
            }
        }
    }
}
