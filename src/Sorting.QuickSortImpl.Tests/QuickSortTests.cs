using Helpers.TestsHelper;
using Microsoft.Extensions.DependencyInjection;
using Sorting.SortAlgorithm;
using System.Threading.Tasks;
using Xunit;

namespace Sorting.QuickSortImpl.Tests
{
    public class QuickSortTests : BaseSortTestsHelper
    {
        public QuickSortTests()
        {
            Algorithm = new QuickSort { IsDebug = false };
        }

        [Fact]
        public async Task Sort_Random_Sequence_ShouldBe_Ok()
        {
            int countOfRetries = 5;

            for (int i = 0; i < countOfRetries; i++)
            {
                // arrange
                var array = GetRandomSequence();
                // act
                await Algorithm.Sort(array);              
                // assert
                Assert.True(array.IsSorted());
            }
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
