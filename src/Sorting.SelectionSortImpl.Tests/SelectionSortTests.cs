using System;
using System.Threading.Tasks;
using Helpers.TestsHelper;
using Sorting.SortAlgorithm;
using Xunit;

namespace Sorting.SelectionSortImpl.Tests
{
    public class SelectionSortTests : BaseSortTestsHelper
    {
        public SelectionSortTests()
        {
            Algorithm = new SelectionSort {IsDebug = true};
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