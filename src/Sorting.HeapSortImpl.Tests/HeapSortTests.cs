using System;
using Helpers.TestsHelper;
using Sorting.SortAlgorithm;
using Xunit;

namespace Sorting.HeapSortImpl.Tests
{
    public class HeapSortTests: BaseSortTestsHelper
    {
        public HeapSortTests()
        {
            Algorithm = new HeapSort() {IsDebug = false};
        }

        [Fact]
        public void Sort_Random_Sequence_ShouldBe_Ok()
        {
            // arrange
            var array = GetRandomSequence();
            // act
            Algorithm.Sort(array).Wait();
            // assert
            Assert.True(array.IsSorted());
        }

        [Fact]
        public void Sort_Sorted_Sequence_ShouldBe_Ok()
        {
            // arrange
            var array = GetSortedSequence();

            // act
            Algorithm.Sort(array).Wait();

            // assert
            Assert.True(array.IsSorted());
        }
    }
}