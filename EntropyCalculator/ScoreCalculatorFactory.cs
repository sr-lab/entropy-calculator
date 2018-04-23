namespace EntropyCalculator
{
    public static class ScoreCalculatorFactory
    {
        public static IScoreCalculator GetScoreCalculator(EntropyMode mode)
        {
            switch (mode)
            {
                case EntropyMode.Shannon:
                    return new ShannonScoreCalculator();
                case EntropyMode.LengthOnly:
                    return new LengthOnlyScoreCalculator();
            }
            return null;
        }
    }
}
