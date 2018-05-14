namespace EntropyCalculator
{
    /// <summary>
    /// A score calculator that returns the Shannon entropy of a password.
    /// </summary>
    public class ShannonScoreCalculator : IScoreCalculator
    {
        /// <summary>
        /// The per-character entropy calculator that underlies this object.
        /// </summary>
        private readonly CharShannonScoreCalculator underlyingCalculator;

        /// <summary>
        /// Initializes a new instance of a score calculator that returns the Shannon entropy of a password.
        /// </summary>
        public ShannonScoreCalculator()
        {
            underlyingCalculator = new CharShannonScoreCalculator();
        }

        public double CalculateScore(string str)
        {
            // Just multiply per-character entropy by length.
            return underlyingCalculator.CalculateScore(str) * str.Length;
        }
    }
}
