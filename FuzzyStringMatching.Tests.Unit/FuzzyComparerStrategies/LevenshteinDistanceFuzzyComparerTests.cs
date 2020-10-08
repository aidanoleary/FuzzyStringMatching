using System;
using FuzzyStringMatching.FuzzyComparerStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyStringMatching.Tests.Unit.FuzzyComparerStrategies
{
    [TestClass]
    public class LevenshteinDistanceFuzzyComparerTests
    {
        private LevenshteinDistanceFuzzyComparer levenshteinComparer;

        [TestInitialize]
        public void Initialize()
        {
            this.levenshteinComparer = new LevenshteinDistanceFuzzyComparer();
        }

        [TestMethod]
        public void Compare_TwoEquivalentStrings_ReturnsZero()
        {
            string firstString = "This is a string";
            string secondString = "This is a string";

            double output = this.levenshteinComparer.Compare(firstString, secondString);
            Assert.AreEqual(0, output);
        }

        [TestMethod]
        public void Compare_TwoStringsOfLengthFourWhereAllCharactersAreDifferent_ReturnsFour()
        {
            string firstString = "abcd";
            string secondString = "efgh";

            double output = this.levenshteinComparer.Compare(firstString, secondString);

            Assert.AreEqual(4, output);
        }

        [TestMethod]
        public void Compare_FirstStringIsEmpty_ReturnsTheLengthOfTheSecondString()
        {
            string firstString = "";
            string secondString = "abcd";

            double output = this.levenshteinComparer.Compare(firstString, secondString);

            Assert.AreEqual(4, output);
        }

        [TestMethod]
        public void Compare_SecondStringIsEmpty_ReturnsTheLengthOfTheFirstString()
        {
            string firstString = "abcd";
            string secondString = "";

            double output = this.levenshteinComparer.Compare(firstString, secondString);

            Assert.AreEqual(4, output);
        }
    }
}
