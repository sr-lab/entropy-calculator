namespace EntropyCalculator
{
    /// <summary>
    /// Represents an entropy score calculator.
    /// </summary>
    public interface IScoreCalculator
    {
        /// <summary>
        /// Returns the entropy score for a password.
        /// </summary>
        /// <param name="str">The password to score.</param>
        /// <returns></returns>
        double CalculateScore(string str);
    }
}
