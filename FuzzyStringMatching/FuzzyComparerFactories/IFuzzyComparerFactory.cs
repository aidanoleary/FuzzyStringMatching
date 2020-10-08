using FuzzyStringMatching.FuzzyComparerStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyStringMatching.FuzzyComparerFactories
{
    public interface IFuzzyComparerFactory
    {
        public IFuzzyComparerStrategy GetFuzzyComparer(FuzzyStringComparerType fuzzyComparerType);
    }
}
