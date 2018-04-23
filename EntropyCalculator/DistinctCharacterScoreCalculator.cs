using System.Linq;

namespace EntropyCalculator
{
    /// <summary>
    /// A score calculator that returns the number of distinct characters in a string.
    /// </summary>
    public class DistinctCharacterScoreCalculator : IScoreCalculator
    {
        public double CalculateScore(string str)
        {
            return str.Distinct().Count();
        }
    }
}
