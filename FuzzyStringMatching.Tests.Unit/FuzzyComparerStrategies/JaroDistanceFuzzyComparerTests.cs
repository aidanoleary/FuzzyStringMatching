using System;
using FuzzyStringMatching.FuzzyComparerStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyStringMatching.Tests.Unit.FuzzyComparerStrategies
{
    [TestClass]
    public class JaroDistanceFuzzyComparerTests
    {
        private JaroDistanceFuzzyComparer jaroDistanceComparer;

        public JaroDistanceFuzzyComparerTests()
        {
            this.jaroDistanceComparer = new JaroDistanceFuzzyComparer();
        }

        [TestMethod]
        public void Compare_TwoEquivalentStrings_ReturnsOne()
        {
            string firstString = "test string";
            string secondString = "test string";

            double output = this.jaroDistanceComparer.Compare(firstString, secondString);
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void Compare_TwoStringsWithAllDifferentChars_ReturnsZero()
        {
            string firstString = "test string";
            string secondString = "zzzzzzzzzzz";

            double output = this.jaroDistanceComparer.Compare(firstString, secondString);
            Assert.AreEqual(0, output);
        }


        [TestMethod]
        public void Compare_FirstStringAndSecondStringEmpty_ReturnsOne()
        {
            string firstString = "";
            string secondString = "";

            double output = this.jaroDistanceComparer.Compare(firstString, secondString);
            Assert.AreEqual(1, output);
        }

        [TestMethod]
        public void Compare_TwoFiveCharacterStringsOneCharacterDifference_ReturnsZeroPointEightSeven()
        {
            string firstString = "testa";
            string secondString = "testb";

            double output = this.jaroDistanceComparer.Compare(firstString, secondString);
            Assert.AreEqual(0.87, Math.Round(output, 2));
        }
    }
}
