﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sorting.SortAlgorithm;

// Time O(n*log(n)), Sapce O(log(n)) 
namespace Sorting.QuickSortImpl
{
    public class QuickSort : ISortAlgorithm
    {
        private int _currentRound;
        private bool _isDebug;

        public bool IsDebug
        {
            get => _isDebug;
            set
            {
                _isDebug = value;
                QuickSortExtensions.Print = _isDebug;
            }
        }

        public bool ShowStatistics { get; set; }

        public Task Sort(IList<int> array)
        {
            return Sort(array, 0, array.Count - 1);
        }

        private async Task Sort(IList<int> array, int left, int right, PivotType type = PivotType.Rand)
        {
            if (left >= right) return;

            if (IsDebug)
                Console.WriteLine($"Recursive call round => {_currentRound++} | left = {left}, right = {right}");

            int pivotIndex = array.GetPivot(left, right, type);
            int partitionIndex = array.Partition(left, right, pivotIndex);

            await Sort(array, left, partitionIndex - 1);
            await Sort(array, partitionIndex, right);
        }
    }
}
