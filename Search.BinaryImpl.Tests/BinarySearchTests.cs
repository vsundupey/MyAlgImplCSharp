using System;
using System.Linq;
using Helpers.TestsHelper;
using Search.SearchAlgorithm;
using Xunit;

namespace Search.BinaryImpl.Tests
{
    public class BinarySearchTests : BaseTestsHelper
    {
        private readonly ISearchAlgorithm _alg;

        public BinarySearchTests()
        {
            _alg = new BinarySearch();
        }

        [Fact]
        public void Search_ShouldBe_Ok()
        {
            var array = GetSortedSequence();      
            var randIndex = new Random().Next(0, array.Count - 1);
            var searchValue = array[randIndex];

            var result = _alg.Find(array, searchValue);
            
            Assert.Equal(searchValue, array[result]);
        }
    }
}