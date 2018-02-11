using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

namespace Sorting.InsertionSortImpl
{
    // Time O(n^2), Space O(1)
    public class InsertionSort : ISortAlgorithm
    {
        public bool IsDebug { get; set; }
        public bool ShowStatistics { get; set; }
        
        public Task Sort(IList<int> array)
        {
            return Task.Run(() =>
            {
                for (int i = 1; i < array.Count; i++)
                {
                    for (int j = i; j > 0; j--)
                    {
                        if(array[j-1] > array[j])
                            array.Swap(j-1, j);
                    }
                }    
            });      
        }
    }
}