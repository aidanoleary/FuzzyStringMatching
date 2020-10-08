using FuzzyStringMatching.FuzzyComparerFactories;
using FuzzyStringMatching.FuzzyComparerStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching
{
    public class FuzzyStringComparerService
    {
        private IFuzzyComparerFactory fuzzyComparerFactory;

        public FuzzyStringComparerService()
        {
            this.fuzzyComparerFactory = new FuzzyComparerFactory();
        }

        public FuzzyStringComparerService(IFuzzyComparerFactory fuzzyComparerFactory)
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
