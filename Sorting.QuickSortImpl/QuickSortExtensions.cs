using System;
using System.Collections.Generic;
using Sorting.SortAlgorithm;

namespace Sorting.QuickSortImpl
{
    public enum PivotType
    {
        First,
        Middle,
        Last,
        Rand
    }

    public static class QuickSortExtensions
    {
        public static bool Print = false;

        /// <summary>
        /// Step 1 - Choose pivot
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetPivot(this IList<int> array, int left, int right, PivotType type = PivotType.Rand)
        {
            if (array.Count < 2) return left;

            switch (type)
            {
                case PivotType.First:
                    return left;
                case PivotType.Middle:
                    return left + (right - left) / 2;
                case PivotType.Last:
                    return right;
                case PivotType.Rand:
                    return new Random().Next(left, right);
            }

            return right;
        }

        /// <summary>
        ///  Step 2 - Partition
        /// </summary>
        /// <param name="array">Source sequence</param>
        /// <param name="left">left marker</param>
        /// <param name="right">right marker</param>
        /// <param name="pivotIndex">Index of current pivot element in array</param>
        /// <returns>Partition index</returns>
        public static int Partition(this IList<int> array, int left, int right, int pivotIndex)
        {
            var pivotValue = array[pivotIndex];
            while (left <= right)
            {
                while (array[left] < pivotValue)
                {
                    if (Print) array.PrintShift(pivotIndex, left, " => ");
                    left++;
                }

                if (Print) array.PrintSelected(pivotIndex, left);

                while (array[right] > pivotValue)
                {
                    if (Print) array.PrintShift(pivotIndex, right, " <= ");
                    right--;
                }

                if (Print) array.PrintSelected(pivotIndex, right);

                if (left <= right)
                {
                    array.Swap(left, right);
                    if (Print) array.PrintSwap(pivotIndex, left, right);

                    left++;
                    right--;
                }
            }
            return left;
        }

        #region Print debug info

        public static void PrintSwap(this IList<int> array, int pivotIndex, int left, int right)
        {
            PrintPivotInfo(pivotIndex, array[pivotIndex]);
            array.PrintSwap(left, right);
        }

        public static void PrintSelected(this IList<int> array, int pivotIndex, int currentIndex)
        {
            PrintPivotInfo(pivotIndex, array[pivotIndex]);
            array.PrintSelected(currentIndex, " |x| ");
        }

        public static void PrintShift(this IList<int> array, int pivotIndex, int currentIndex, string direction)
        {
            PrintPivotInfo(pivotIndex, array[pivotIndex]);
            array.PrintShift(currentIndex, direction);
        }

        private static void PrintPivotInfo(int pivotIndex, int pivotValue)
        {
            Console.Write($"a[{pivotIndex}] = {pivotValue} | ");
        }

        #endregion
    }
}
