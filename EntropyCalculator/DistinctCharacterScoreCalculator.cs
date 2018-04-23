using System.Collections.Generic;

namespace EntropyCalculator
{
    public class DistinctCharacterScoreCalculator : IScoreCalculator
    {
        public double CalculateScore(string str)
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
    }
}
