using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
    public abstract class BaseSortingStrategy : ISortingStrategy
    {
        public void Sort<T>(IList<T> collection)
        {
            Sort(collection, Comparer<T>.Default);
        }

        public abstract void Sort<T>(IList<T> collection, IComparer<T> comparer);
    }
}