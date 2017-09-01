using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Sorting.SortAlgorithm;
using System;

namespace Helpers.TestsHelper
{
    public abstract class BaseSortTestsHelper
    {
        protected ServiceCollection service;
        protected ISortAlgorithm Algorithm;
        Random _rand = new Random();

        #region Sorted properties

        #endregion

        protected BaseSortTestsHelper()
        {
            service = new ServiceCollection();
        }

        public IList<int> GetRandomSequence(int count = 10)
        {
            int[] array = new int[count];
            for(int i = 0; i < count; i++) array[i] = _rand.Next(0, 100);
            return array;
        }

        public IList<int> GetSortedSequence(int count = 10)
        {
            int[] array = new int[count];
            for (int i = 0; i < count; i++) array[i] = i;
            return array;
        }
    }
}
