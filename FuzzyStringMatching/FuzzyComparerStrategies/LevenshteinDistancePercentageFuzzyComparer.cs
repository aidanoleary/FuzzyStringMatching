using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching.FuzzyComparerStrategies
{
    public class LevenshteinDistancePercentageFuzzyComparer : IFuzzyComparerStrategy
    {
        private IFuzzyComparerStrategy levenshteinDistanceComparer;

        public LevenshteinDistancePercentageFuzzyComparer(IFuzzyComparerStrategy levenshteinDistanceComparer)
        {
            this.levenshteinDistanceComparer = levenshteinDistanceComparer;
        }

        public double Compare(string firstString, string secondString)
        {
            double computedLevenshteinDistance = this.levenshteinDistanceComparer.Compare(firstString, secondString);
            return Math.Round(100 * (1 - (computedLevenshteinDistance / Math.Max(firstString.Length, secondString.Length))),2);
        }
    }
}
