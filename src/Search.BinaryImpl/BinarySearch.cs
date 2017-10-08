using System.Collections.Generic;
using System.Linq;
using Search.SearchAlgorithm;

namespace Search.BinaryImpl
{
    // Time: O(log(n))
    // Space: O(n)
    public class BinarySearch : ISearchAlgorithm
    {
        public int Find(IList<int> array, int value)
        {
            if (!array.Any()) return -1;

            return Search(array, value, 0, array.Count - 1);
        }

        private int Search(IList<int> array, int value, int start, int end)
        {
            if (start == end)
            {
                if (array[start] == value) return start;
                return -1;
            }

            var median = start + (end - start) / 2;

            if (array[median] >= value)
                return Search(array, value, start, median);

            return Search(array, value, median + 1, end);
        }
    }
}