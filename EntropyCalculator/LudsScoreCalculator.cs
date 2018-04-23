using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntropyCalculator
{
    public class LudsScoreCalculator : IScoreCalculator
    {
        public double CalculateScore(string str)
        {
            var x = 0;
            x += str.Any(c => char.IsLower(c)) ? 1 : 0;
            x += str.Any(c => char.IsUpper(c)) ? 1 : 0;
            x += str.Any(c => char.IsDigit(c)) ? 1 : 0;
            x += str.Any(c => char.IsSymbol(c)) ? 1 : 0;
            return x;
        }
    }
}
