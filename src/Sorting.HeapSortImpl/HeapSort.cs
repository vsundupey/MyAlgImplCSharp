using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

namespace Sorting.HeapSortImpl
{
    // Time O(n*log(n)), Space O(1)
    public class HeapSort : ISortAlgorithm
    {
        public bool IsDebug { get; set; }
        public bool ShowStatistics { get; set; }
        
        public Task Sort(IList<int> array)
        {
            return Task.Run(() =>
            {
                int n = array.Count;
 
                // Step 1: Build heap (rearrange array)
                for (int i = n / 2 - 1; i >= 0; i--)
                    Heapify(array, n, i);
 
                // Step 2: One by one extract an element from heap
                for (int i=n-1; i>=0; i--)
                {
                    // Move current root to end
                    array.Swap(0, i);
                    // call max heapify on the reduced heap
                    Heapify(array, i, 0);
                }
            });
        }
        
        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        private void Heapify(IList<int> array, int n, int i)
        {
            int largest = i;  // Initialize largest as root
            int left = 2*i + 1;  // left = 2*i + 1
            int right = 2*i + 2;  // right = 2*i + 2
 
            // Step 1: If left child is larger than root
            if (left < n && array[left] > array[largest])
                largest = left;
 
            // Step 2: If right child is larger than largest so far
            if (right < n && array[right] > array[largest])
                largest = right;
 
            // Step 3: If largest is not root
            if (largest != i)
            {
                array.Swap(largest, i);
                // Recursively heapify the affected sub-tree
                Heapify(array, n, largest);
            }
        }
    }
}