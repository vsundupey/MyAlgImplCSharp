using System.Collections.Generic;

namespace Search.SearchAlgorithm
{
    public interface ISearchAlgorithm
    {
        /// <summary>
        /// Basic search method 
        /// </summary>
        /// <param name="array">Input data array</param>
        /// <param name="value">value of search item</param>
        /// <returns>index of search item, returns -1 if value not found</returns>
        int Find(IList<int> array, int value);
    }
}