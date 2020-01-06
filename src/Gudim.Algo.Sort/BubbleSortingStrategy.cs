using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
    public sealed class BubbleSortingStrategy : BaseSortingStrategy 
    {
        public override void Sort<T>(IList<T> collection, IComparer<T> comparer)
        {
            var size = collection.Count;

            for (var i = 0; i < size; i++)
            {
                for (var j = 1; j < size; j++)
                {
                    var left = collection[j - 1];
                    var right = collection[j];

                    if (comparer.Compare(left, right) <= 0) 
                        continue;

                    collection[j - 1] = right;
                    collection[j] = left;
                }
            }
        }
    }
}
