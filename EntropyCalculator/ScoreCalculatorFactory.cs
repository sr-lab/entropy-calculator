namespace EntropyCalculator
{
    /// <summary>
    /// A static factory for score calculator instances.
    /// </summary>
    public static class ScoreCalculatorFactory
    {
        /// <summary>
        /// Returns a score calculator based on the entropy mode provided.
        /// </summary>
        /// <param name="mode">The entropy mode.</param>
        /// <returns></returns>
        public static IScoreCalculator GetScoreCalculator(EntropyMode mode)
        {
            switch (mode)
            {
                case EntropyMode.CharShannon:
                    return new CharShannonScoreCalculator();
                case EntropyMode.Shannon:
                    return new ShannonScoreCalculator();
                case EntropyMode.LengthOnly:
                    return new LengthOnlyScoreCalculator();
                case EntropyMode.DistinctCharacter:
                    return new DistinctCharacterScoreCalculator();
                case EntropyMode.LudsClasses:
                    return new LudsScoreCalculator();
            }
            return null;
        }
    }
}
