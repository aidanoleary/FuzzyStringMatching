using FuzzyStringMatching.FuzzyComparerFactories;
using FuzzyStringMatching.FuzzyComparerStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyStringMatching.Tests.Unit.FuzzyComparerFactories
{
    [TestClass]
    public class FuzzyComparerFactoryTests
    {
        private FuzzyComparerFactory fuzzyComparerFactory;

        public FuzzyComparerFactoryTests()
        {
            this.fuzzyComparerFactory = new FuzzyComparerFactory();
        }

        [DataTestMethod]
        [DataRow(FuzzyStringComparerType.LevenshteinDistance, nameof(LevenshteinDistanceFuzzyComparer))]
        [DataRow(FuzzyStringComparerType.LevenshteinDistanceRecursive, nameof(LevenshteinDistanceRecursiveFuzzyComparer))]
        [DataRow(FuzzyStringComparerType.LevenshteinDistancePercentage, nameof(LevenshteinDistancePercentageFuzzyComparer))]
        [DataRow(FuzzyStringComparerType.JaroDistance, nameof(JaroDistanceFuzzyComparer))]
        public void GetFuzzyComparer_ValidComparerType_ShouldReturnTheCorrectStrategy(FuzzyStringComparerType comparerType, string expectedComparerTypeName)
        {
            // Act
            IFuzzyComparerStrategy returnedComparer = this.fuzzyComparerFactory.GetFuzzyComparer(comparerType);

            // Assert
            Assert.AreEqual(expectedComparerTypeName, returnedComparer.GetType().Name);
        }
    }
}
