using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Helpers.TestsHelper
{
    public abstract class BaseTestsHelper
    {
        private readonly Random _rand;
        
        protected BaseTestsHelper()
        {
            _rand = new Random();
        }
        
        protected IList<int> GetRandomSequence(int count = 10)
        {
            var array = new int[count];
            for(var i = 0; i < count; i++) array[i] = _rand.Next(-100, 100);
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