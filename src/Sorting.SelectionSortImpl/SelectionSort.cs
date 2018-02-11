using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

namespace Sorting.SelectionSortImpl
{
    // Time O(n^2), Space O(1)
    public class SelectionSort : ISortAlgorithm
    {
        public bool IsDebug { get; set; }
        public bool ShowStatistics { get; set; }

        public Task Sort(IList<int> array)
        {
            int min = 0;
            
            return Task.Run(() =>
            {
                for (int i = 0; i < array.Count; i++)
                {
                    min = i;
                    for (int j = i; j < array.Count; j++)               
                        if (array[j] < array[min]) min = j;
                        
                    array.PrintSelected(min, "");
                    array.PrintSwap(i, min);
                    array.Swap(i, min);
                }
            });
        }
    }
}