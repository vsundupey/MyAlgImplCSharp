using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorting.SortAlgorithm
{
    public interface ISortAlgorithm
    {
        bool IsDebug { get; set; }

        bool ShowStatistics { get; set; }

        Task Sort(IList<int> array);
    }

    public static class SortingArrayExtension
    {      
        public static void Print(this IList<int> array)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Join(" ", array.Select(v => v.ToString())));
        }

        //TODO need improve perfomance for big arrays
        public static bool IsSorted(this IList<int> array)
        {
            if (array.Count == 1) return true;

            for (int i = 0; i < array.Count - 1; i++)
                if (array[i] > array[i + 1]) return false;

            return true;
        }

        public static void PrintSwap(this IList<int> array, int left, int right)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (i == left || i == right) Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{array[i]} ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write(" <=> ");
            Console.WriteLine();
        }

        public static void PrintShift(this IList<int> array, int currentIndex, string direction, ConsoleColor color = ConsoleColor.Red)
        {
            PrintWithColoredSelectedElement(array, currentIndex, direction, color);
        }

        public static void PrintSelected(this IList<int> array, int currentIndex, string direction, ConsoleColor color = ConsoleColor.Blue)
        {
            PrintWithColoredSelectedElement(array, currentIndex, direction, color);
        }

        private static void PrintWithColoredSelectedElement(IList<int> array, int currentIndex, string direction, ConsoleColor color = ConsoleColor.Blue)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (i == currentIndex) Console.ForegroundColor = color;
                Console.Write($"{array[i]} ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write(direction);
            Console.WriteLine();
        }

        public static void Swap(this IList<int> array, int index1, int index2)
        {
            int tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }
    }
}
