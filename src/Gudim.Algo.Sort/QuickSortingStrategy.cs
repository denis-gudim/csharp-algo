using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace Gudim.Algo.Sort
{
	public sealed class QuickSortingStrategy : BaseSortingStrategy
	{
		private readonly IQuickSortingPartitionStrategy _partitionStrategy;

		public QuickSortingStrategy()
			: this(new LomutoPartitionStrategy())
		{
			
		}

		public QuickSortingStrategy(IQuickSortingPartitionStrategy partitionStrategy)
		{
			_partitionStrategy = partitionStrategy;
		}

		public override void Sort<T>(IList<T> collection, IComparer<T> comparer)
		{
			SortInternal(collection, comparer, 0, collection.Count-1);
		}

		private void SortInternal<T>(IList<T> collection, IComparer<T> comparer, int low, int high)
		{
			if(high < low) return;

			var p = _partitionStrategy.Partition(collection, comparer, low, high);

			SortInternal(collection, comparer, low, p - 1);
			SortInternal(collection, comparer, p + 1, high);
		}
	}
}