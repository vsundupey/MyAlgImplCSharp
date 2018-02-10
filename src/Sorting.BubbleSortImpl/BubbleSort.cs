using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

namespace Sorting.BubbleSortImpl
{
    // Time O(n^2), Space O(1)
    public class BubbleSort : ISortAlgorithm
    {
        public bool IsDebug { get; set; }
        public bool ShowStatistics { get; set; }
        
        public Task Sort(IList<int> array)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < array.Count - 1; i++)
                {
                    for (int j = 0; j < array.Count - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                            array.Swap(j, j + 1);
                    }
                }
            });
        }
    }
}