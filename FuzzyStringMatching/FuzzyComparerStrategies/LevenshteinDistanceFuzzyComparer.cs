using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching.FuzzyComparerStrategies
{
    public class LevenshteinDistanceFuzzyComparer : IFuzzyComparerStrategy
    {
        public double Compare(string firstString, string secondString)
        {
            int firstStringLength = firstString.Length;
            int secondStringLength = secondString.Length;
            int[,] d = new int[firstStringLength + 1, secondStringLength + 1];

            if (firstStringLength == 0)
            {
                return secondStringLength;
            }

            if (secondStringLength == 0)
            {
                return firstStringLength;
            }

            for (int i = 0; i <= firstStringLength; i++)
                d[i, 0] = i;
            for (int j = 0; j <= secondStringLength; j++)
                d[0, j] = j;

            for (int j = 1; j <= secondStringLength; j++)
                for (int i = 1; i <= firstStringLength; i++)
                    if (firstString[i - 1] == secondString[j - 1])
                        d[i, j] = d[i - 1, j - 1];  //no operation
                    else
                        d[i, j] = Math.Min(Math.Min(
                            d[i - 1, j] + 1,    //a deletion
                            d[i, j - 1] + 1),   //an insertion
                            d[i - 1, j - 1] + 1 //a substitution
                            );
            return d[firstStringLength, secondStringLength];
        }
    }
}
