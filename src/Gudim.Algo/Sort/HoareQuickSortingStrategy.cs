using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
	public sealed class HoareQuickSortingStrategy : BaseSortingStrategy
	{
		public override void Sort<T>(IList<T> collection, IComparer<T> comparer)
		{
			SortInternal(collection, comparer, 0, collection.Count - 1);
		}

		private void SortInternal<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
		{
			if (high <= low) return;

			var p = Partition(collection, comparer, low, high);

			SortInternal(collection, comparer, low, p);
			SortInternal(collection, comparer, p + 1, high);
		}

		private int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
		{
			var i = low - 1;
			var j = high + 1;
			var pivot = collection[low];

			while (true)
			{
				while (comparer.Compare(collection[++i], pivot) < 0) { }
				while (comparer.Compare(collection[--j], pivot) > 0) { }

				if (i >= j) return j;

				var tmp = collection[i];
				
				collection[i] = collection[j];
				collection[j] = tmp;
			}
		}
	}
}