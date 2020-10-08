using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyStringMatching.FuzzyComparerStrategies;

namespace FuzzyStringMatching.Tests.Unit.FuzzyComparerStrategies
{

    [TestClass]
    public class LevenshteinDistanceRecursiveFuzzyComparerTests
    {
        private LevenshteinDistanceRecursiveFuzzyComparer levenshteinRecursiveComparer;

        [TestInitialize]
        public void Initialize()
        {
            levenshteinRecursiveComparer = new LevenshteinDistanceRecursiveFuzzyComparer();
        }

        [TestMethod]
        public void Compare_TwoEquivalentStrings_ReturnsZero()
        {
            string firstString = "string";
            string secondString = "string";

            double output = this.levenshteinRecursiveComparer.Compare(firstString, secondString);
            Assert.AreEqual(0, output);
        }
    }
}
