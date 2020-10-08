using FuzzyStringMatching.FuzzyComparerStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyStringMatching.FuzzyComparerFactories
{
    public class FuzzyComparerFactory : IFuzzyComparerFactory
    {
        public IFuzzyComparerStrategy GetFuzzyComparer(FuzzyStringComparerType fuzzyComparerType)
        {
            switch (fuzzyComparerType)
            {
                case FuzzyStringComparerType.JaroDistance:
                    return new JaroDistanceFuzzyComparer();

                case FuzzyStringComparerType.LevenshteinDistance:
                    return new LevenshteinDistanceFuzzyComparer();

                case FuzzyStringComparerType.LevenshteinDistanceRecursive:
                    return new LevenshteinDistanceRecursiveFuzzyComparer();

                case FuzzyStringComparerType.LevenshteinDistancePercentage:
                    return new LevenshteinDistancePercentageFuzzyComparer(new LevenshteinDistanceFuzzyComparer());

                default:
                    throw new Exception("No comparer for the specified type");
            }
        }
    }
}
