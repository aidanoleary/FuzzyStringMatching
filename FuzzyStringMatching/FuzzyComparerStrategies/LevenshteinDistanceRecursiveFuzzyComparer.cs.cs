using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching.FuzzyComparerStrategies
{
    public class LevenshteinDistanceRecursiveFuzzyComparer : IFuzzyComparerStrategy
    {
        public double Compare(string firstString, string secondString)
        {
            return Compare(firstString, firstString.Length, secondString, secondString.Length);
        }

        private double Compare(string firstString, int firstStringLength, string secondString, int secondStringLength)
        {
            double cost = 0;

            // Stopping case
            if (firstStringLength == 0) return secondStringLength;
            if (secondStringLength == 0) return firstStringLength;

            // Test if the last characters are a match
            if (firstString[firstStringLength - 1] == secondString[secondStringLength - 1])
                cost = 0;
            else
                cost = 1;

            // Return the minimum of delete character from first string, 
            // delete character from second string, and delete character from both
            return Math.Min(Math.Min(
                Compare(firstString, firstStringLength - 1, secondString, secondStringLength) + 1,
                Compare(firstString, firstStringLength, secondString, secondStringLength - 1) + 1),
                Compare(firstString, firstStringLength - 1, secondString, secondStringLength - 1) + cost);
        }
    }
}
