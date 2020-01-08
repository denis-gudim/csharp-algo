using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace Gudim.Algo.Sort
{
	public sealed class LomutoQuickSortingStrategy : BaseSortingStrategy
	{
		public override void Sort<T>(IList<T> collection, IComparer<T> comparer)
		{
			SortInternal(collection, comparer, 0, collection.Count-1);
		}

		private void SortInternal<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
		{
			if(high < low) return;

			var p = Partition(collection, comparer, low, high);

			SortInternal(collection, comparer, low, p - 1);
			SortInternal(collection, comparer, p + 1, high);
		}

		private int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
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