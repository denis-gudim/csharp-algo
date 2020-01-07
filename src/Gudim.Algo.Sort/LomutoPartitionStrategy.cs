using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
	public sealed class LomutoPartitionStrategy : IQuickSortingPartitionStrategy
	{
		public int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
		{
			var i = low;
			var pivot = collection[high];

			for (var j = low; j < high; j++)
			{
				var item = collection[j];

				if (comparer.Compare(item, pivot) > 0) continue;

				collection[j] = collection[i];
				collection[i] = item;

				i++;
			}

			collection[high] = collection[i];
			collection[i] = pivot;

			return i;
		}
	}
}