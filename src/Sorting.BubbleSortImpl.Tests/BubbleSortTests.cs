using System;
using System.Threading.Tasks;
using Helpers.TestsHelper;
using Sorting.SortAlgorithm;
using Xunit;

namespace Sorting.BubbleSortImpl.Tests
{
    public class BubbleSortTests : BaseSortTestsHelper
    {
        public BubbleSortTests()
        {
            Algorithm = new BubbleSort {IsDebug = false};
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