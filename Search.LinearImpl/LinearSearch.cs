using System;
using System.Collections.Generic;
using System.Linq;
using Search.SearchAlgorithm;

namespace Search.LinearImpl
{
    // Time: Avg O(n), Worst O(n), Best O(1)
    // Space: O(1)
    public class LinearSearch : ISearchAlgorithm
    {
        public int Find(IList<int> array, int value)
        {
            if (array == null) throw new ArgumentNullException();

            if (!array.Any()) return -1;

            for (int i = 0; i < array.Count; i++)
                if (array[i] == value) return i;


            return -1;
        }
    }
}