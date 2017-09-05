using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Sorting.SortAlgorithm;
using System;

namespace Helpers.TestsHelper
{
    public abstract class BaseSortTestsHelper
    {
        protected readonly ServiceCollection Service;
        protected ISortAlgorithm Algorithm;
        private readonly Random _rand = new Random();

        #region Sorted properties

        #endregion

        protected BaseSortTestsHelper()
        {
            Service = new ServiceCollection();
        }

        protected IList<int> GetRandomSequence(int count = 10)
        {
            int[] array = new int[count];
            for(int i = 0; i < count; i++) array[i] = _rand.Next(0, 100);
            return array;
        }

        protected IList<int> GetSortedSequence(int count = 10)
        {
            var array = new int[count];
            for (var i = 0; i < count; i++) array[i] = i;
            return array;
        }
    }
}
