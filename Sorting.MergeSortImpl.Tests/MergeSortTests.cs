using System;
using System.Threading.Tasks;
using Helpers.TestsHelper;
using Sorting.SortAlgorithm;
using Xunit;

namespace Sorting.MergeSortImpl.Tests
{
    public class MergeSortTests : BaseSortTestsHelper
    {
        public MergeSortTests()
        {
            Algorithm = new MergeSort {IsDebug = false};
        }

        [Fact]
        public async Task Sort_Random_Sequence_ShouldBe_Ok()
        {
            // arrange
            var array = GetRandomSequence();
            // act
            await Algorithm.Sort(array);
            // assert
            Assert.True(array.IsSorted());
        }

        [Fact]
        public async Task Sort_Sorted_Sequence_ShouldBe_Ok()
        {
            // arrange
            var array = GetSortedSequence();

            // act
            await Algorithm.Sort(array);

            // assert
            Assert.True(array.IsSorted());
        }
    }
}