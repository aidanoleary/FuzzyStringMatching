using System;
using FuzzyStringMatching.FuzzyComparerStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyStringMatching.Tests.Unit.FuzzyComparerStrategies
{
    [TestClass]
    public class LevenshteinDistancePercentageFuzzyComparerTests
    {
        private LevenshteinDistancePercentageFuzzyComparer levenshteinPercentageComparer;

        public LevenshteinDistancePercentageFuzzyComparerTests()
        {
            levenshteinPercentageComparer = new LevenshteinDistancePercentageFuzzyComparer(new LevenshteinDistanceFuzzyComparer());
        }

        [TestMethod]
        public void Compare_TwoEquivalentStrings_ReturnsOneHundred()
        {
            string firstString = "This is a string";
            string secondString = "This is a string";

            double percentage = this.levenshteinPercentageComparer.Compare(firstString, secondString);
            Assert.AreEqual(100, percentage);
        }

        [TestMethod]
        public void Compare_TwoSixCharacterStringsWithTwoDifferences_ReturnsSixtySix()
        {
            string firstString = "string";
            string secondString = "straag";

            double percentage = this.levenshteinPercentageComparer.Compare(firstString, secondString);
            Assert.AreEqual(66.67, percentage);
        }

        [TestMethod]
        public void Compare_TwoFiveCharacterStringsOneCharacterDifference_ReturnsEighty()
        {
            string firstString = "testa";
            string secondString = "testb";

            double output = this.levenshteinPercentageComparer.Compare(firstString, secondString);
            Assert.AreEqual(80, output);
        }
    }
}
