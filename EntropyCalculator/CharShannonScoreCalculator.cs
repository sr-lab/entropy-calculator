using System;
using System.Collections.Generic;

namespace EntropyCalculator
{
    /// <summary>
    /// A score calculator that returns the per-character Shannon entropy of a password.
    /// </summary>
    public class CharShannonScoreCalculator : IScoreCalculator
    {
        public double CalculateScore(string str)
        {
            // Get counts of distinct characters in `str`.
            var map = new Dictionary<char, int>();
            foreach (char chr in str)
            {
                if (!map.ContainsKey(chr))
                {
                    map.Add(chr, 1);
                }
                else
                {
                    map[chr] += 1;
                }
            }

            // Calculate per-character entropy.
            double result = 0.0;
            int len = str.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }
            return result;
        }
    }
}
