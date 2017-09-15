using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

namespace Sorting.MergeSortImpl
{
    public class MergeSort : ISortAlgorithm
    {
        public bool IsDebug { get; set; }
        
        public bool ShowStatistics { get; set; }
        
        public Task Sort(IList<int> array)
        {
            return Sort(array, 0, array.Count - 1);
        }

        private static async Task Sort(IList<int> array, int leftStart, int rightEnd)
        {
            if(leftStart >= rightEnd) return;

            int middle = (leftStart + rightEnd) / 2;
            
            await Sort(array, leftStart, middle);
            await Sort(array, middle + 1, rightEnd);
            MergeHalves(array, leftStart, rightEnd);
        }

        private static void MergeHalves(IList<int> array, int leftStart, int rightEnd)
        {
            int leftEnd = (leftStart + rightEnd) / 2;
            int pos1 = leftStart;
            int pos2 = leftEnd + 1;
            int tmpPos = 0;

            int tmpSize = rightEnd - pos1 + 1;
            int[] tmp = new int[tmpSize];

            while (pos1 <= leftEnd && pos2 <=rightEnd )
            {
                if (array[pos1] < array[pos2]) tmp[tmpPos++] = array[pos1++];
                if (array[pos1] > array[pos2]) tmp[tmpPos++] = array[pos2++];   
            }

            while (pos1 <= leftEnd) tmp[tmpPos++] = array[pos1++];
            while (pos2 <= rightEnd) tmp[tmpPos++] = array[pos2++];

            for (int i = 0; i < tmpSize; i++)           
                array[leftStart + i] = tmp[i];
            
        }
    }
}