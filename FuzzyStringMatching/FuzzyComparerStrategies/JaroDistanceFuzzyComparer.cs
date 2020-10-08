using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching.FuzzyComparerStrategies
{
    public class JaroDistanceFuzzyComparer : IFuzzyComparerStrategy
    {
        public double Compare(string firstString, string secondString)
        {
            int firstStringLength = firstString.Length;
            int secondStringLength = secondString.Length;

            if (firstStringLength == 0 && secondStringLength == 0) return 1;

            int matchDistance = Math.Max(firstStringLength, secondStringLength) / 2 - 1;

            bool[] firstStringMatches = new bool[firstStringLength];
            bool[] secondStringMatches = new bool[secondStringLength];

            int matches = 0;
            int transpositions = 0;

            for (int i = 0; i < firstStringLength; i++)
            {
                int start = Math.Max(0, i - matchDistance);
                int end = Math.Min(i + matchDistance + 1, secondStringLength);

                for (int j = start; j < end; j++)
                {
                    if (secondStringMatches[j]) continue;
                    if (firstString[i] != secondString[j]) continue;
                    firstStringMatches[i] = true;
                    secondStringMatches[j] = true;
                    matches++;
                    break;
                }
            }

            if (matches == 0) return 0;

            int k = 0;
            for (int i = 0; i < firstStringLength; i++)
            {
                if (!firstStringMatches[i]) continue;
                while (!secondStringMatches[k]) k++;
                if (firstString[i] != secondString[k]) transpositions++;
                k++;
            }

            return (((double)matches / firstStringLength) +
                    ((double)matches / secondStringLength) +
                    (((double)matches - transpositions / 2.0) / matches)) / 3.0;
        }
    }
}
