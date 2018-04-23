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

        static int ClassesInString(string str)
        {
            var x = 0;
            x += str.Any(c => char.IsLower(c)) ? 1 : 0;
            x += str.Any(c => char.IsUpper(c)) ? 1 : 0;
            x += str.Any(c => char.IsDigit(c)) ? 1 : 0;
            x += str.Any(c => char.IsSymbol(c)) ? 1 : 0;
            return x;
        }

        static int DistinctCharactersInString(string str)
        {
            var chars = new List<char>();
            foreach (var c in str)
            {
                if (!chars.Contains(c))
                {
                    chars.Add(c);
                }
            }
            return chars.Count;
        }


        static double Entropy(string str, EntropyMode mode)
        {
            var length = (double)str.Length;
            switch (mode)
            {
                case EntropyMode.CharacterClass:
                    return ((double)ClassesInString(str)) * length;
                case EntropyMode.DistinctCharacter:
                    return ((double)DistinctCharactersInString(str)) * length;
            }
            return 0;
        }
        
        /// <summary>
        /// returns bits of entropy represented in a given string, per 
        /// http://en.wikipedia.org/wiki/Entropy_(information_theory) 
        /// </summary>
        public static double ShannonEntropy(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] += 1;
            }

            double result = 0.0;
            int len = s.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }

            return result;
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
            var mode = EntropyMode.CharacterClass;
            if (args.Length == 2 && args[1] == "-d")
            {
                mode = EntropyMode.DistinctCharacter;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]}:{ShannonEntropy(input[i])}");
            }
        }
    }
}
