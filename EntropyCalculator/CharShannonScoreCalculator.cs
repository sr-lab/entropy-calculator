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
            var map = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c] += 1;
                }
            }
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
