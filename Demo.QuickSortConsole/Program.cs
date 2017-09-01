using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Sorting.SortAlgorithm;
using Sorting.QuickSortImpl;

namespace Demo.QuickSortConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();

            var serviceProvider = service.AddSingleton<ISortAlgorithm, QuickSort>().BuildServiceProvider();
            ISortAlgorithm algorithm = serviceProvider.GetService<ISortAlgorithm>();

            IList<int> array = new[] { 9, 4, 6, 7, 5, 8, 3, 1, 2 };

            Console.WriteLine("Sequence of numbers before:");
            array.Print();

            Console.WriteLine("Sorting --> ");
            algorithm.Sort(array).Wait();

            Console.WriteLine("Sequence of numbers after:");
            array.Print();

            Console.ReadLine();
        }
    }
}
