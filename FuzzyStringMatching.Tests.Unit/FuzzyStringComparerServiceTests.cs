using System;
using FuzzyStringMatching.FuzzyComparerFactories;
using FuzzyStringMatching.FuzzyComparerStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FuzzyStringMatching.Tests.Unit
{
    [TestClass]
    public class FuzzyStringComparerServiceTests
    {

        private Mock<IFuzzyComparerFactory> factoryMock;
        private Mock<IFuzzyComparerStrategy> strategyMock;
        private FuzzyStringComparerService fuzzyStringComparer;

        [TestInitialize]
        public void Initialize()
        {
            factoryMock = new Mock<IFuzzyComparerFactory>();
            strategyMock = new Mock<IFuzzyComparerStrategy>();

            factoryMock.Setup(f => f.GetFuzzyComparer(It.IsAny<FuzzyStringComparerType>())).Returns(strategyMock.Object);

            fuzzyStringComparer = new FuzzyStringComparerService(factoryMock.Object);
        }

        [TestMethod]
        public void CompareStrings_ShouldGetComparerFromFactoryUsingType()
        {
            // Arrange
            FuzzyStringComparerType inputComparerType = FuzzyStringComparerType.LevenshteinDistance;

            // Act
            this.fuzzyStringComparer.CompareStrings(inputComparerType, "Test", "Test");

            // Assert
            factoryMock.Verify(f => f.GetFuzzyComparer(inputComparerType), Times.Once);
        }

        [TestMethod]
        public void CompareStrings_ShouldCallStrategiesCompareMethodWithInputStrings()
        {
            // Arrange
            string inputStringOne = "Test1";
            string inputStringTwo = "Test2";

            // Act
            this.fuzzyStringComparer.CompareStrings(FuzzyStringComparerType.LevenshteinDistance, inputStringOne, inputStringTwo);

            // Assert
            strategyMock.Verify(s => s.Compare(inputStringOne, inputStringTwo));
        }

    }
}
