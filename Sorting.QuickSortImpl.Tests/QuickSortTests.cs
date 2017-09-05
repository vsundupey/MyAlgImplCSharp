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
            Algorithm = Service.AddSingleton<ISortAlgorithm, QuickSort>()
                .BuildServiceProvider()
                .GetService<ISortAlgorithm>();

            if (Algorithm is QuickSort algorithm) algorithm.IsDebug = false;
        }

        [Fact]
        public async Task Sort_Random_Sequence_ShouldBe_Ok()
        {
            try
            {
                // arrange
                var array = GetRandomSequence();
            
                // act
                await Algorithm.Sort(array);
            
                array.Print();
            
                // assert
                Assert.True(array.IsSorted());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
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
