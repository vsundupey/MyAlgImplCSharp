using Helpers.TestsHelper;
using Microsoft.Extensions.DependencyInjection;
using Sorting.SortAlgorithm;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sorting.QuickSortImpl.Tests
{
    public class QuickSortTests : BaseSortTestsHelper
    {       
        public QuickSortTests()
        {
            Algorithm = service.AddSingleton<ISortAlgorithm, QuickSort>()
                .BuildServiceProvider()
                .GetService<ISortAlgorithm>();
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
