namespace EntropyCalculator
{
    /// <summary>
    /// A score calculator that just returns the length of the given string.
    /// </summary>
    public class LengthOnlyScoreCalculator : IScoreCalculator
    {
        public double CalculateScore(string str)
        {
            return str.Length;
        }
    }
}
