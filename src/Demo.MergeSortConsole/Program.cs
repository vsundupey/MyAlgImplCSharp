using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Sorting.MergeSortImpl;
using Sorting.SortAlgorithm;

namespace Demo.MergeSortConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();

            var serviceProvider = service.AddSingleton<ISortAlgorithm, MergeSort>().BuildServiceProvider();
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