using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
    public interface ISortingStrategy
    {
        void Sort<T>(IList<T> collection);
        void Sort<T>(IList<T> collection, IComparer<T> comparer);
    }
}