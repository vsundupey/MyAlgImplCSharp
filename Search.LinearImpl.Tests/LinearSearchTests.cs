using System;
using System.Linq;
using Helpers.TestsHelper;
using Search.SearchAlgorithm;
using Xunit;

namespace Search.LinearImpl.Tests
{   
    public class LinearSearchTests : BaseTestsHelper
    {
        private readonly ISearchAlgorithm _alg;

        public LinearSearchTests()
        {
            _alg = new LinearSearch();
        }

        [Fact]
        public void Search_ShouldBe_Ok()
        {
            var array = GetRandomSequence();      
            var randIndex = new Random().Next(0, array.Count - 1);
            var searchValue = array[randIndex];

            var result = _alg.Find(array, searchValue);
            
            Assert.Equal(randIndex, result);
        }
        
        [Fact]
        public void Search_ShouldBe_Negative()
        {
            var array = GetRandomSequence();  // range between -100 and 100    
            var searchValue = 1000;

            var result = _alg.Find(array, searchValue);
            
            Assert.Equal(-1, result);
        }
    }
}