using FuzzyStringMatching.FuzzyComparerFactories;
using FuzzyStringMatching.FuzzyComparerStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching
{
    public class FuzzyStringMatchingService
    {
        private IFuzzyComparerFactory fuzzyComparerFactory;

        public FuzzyStringMatchingService()
        {
            this.fuzzyComparerFactory = new FuzzyComparerFactory();
        }

        public FuzzyStringMatchingService(IFuzzyComparerFactory fuzzyComparerFactory)
        {
            this.fuzzyComparerFactory = fuzzyComparerFactory;
        }

        public double CompareStrings(FuzzyStringComparerType fuzzyComparerType, string stringOne, string stringTwo)
        {
            IFuzzyComparerStrategy comparerStrategy = fuzzyComparerFactory.GetFuzzyComparer(fuzzyComparerType);
            return comparerStrategy.Compare(stringOne, stringTwo);
        }

    }
}
