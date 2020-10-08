using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyStringMatching
{
    public enum FuzzyStringComparerType
    {
        LevenshteinDistance,
        LevenshteinDistancePercentage,
        LevenshteinDistanceRecursive,
        JaroDistance
    }
}
