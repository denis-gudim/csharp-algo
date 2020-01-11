using System.Collections;
using System.Collections.Generic;

namespace Gudim.Algo.Search
{
	public sealed class BinarySearchStrategy : BaseSearchStrategy
	{
		public override int Find<T>(IList<T> sequence, T item, IComparer<T> comparer)
		{
			return FindInternal(sequence, item, comparer, 0, sequence.Count - 1);
		}

		public int FindInternal<T>(IList<T> sequence, T item, IComparer<T> comparer, int low, int high)
		{
			if (low > high)
				return -1;

			var pivot = (low + high) / 2;
			var result = comparer.Compare(item, sequence[pivot]);

			if (result == 0)
				return pivot;

			if (result < 0)
				return FindInternal<T>(sequence, item, comparer, low, pivot - 1);

			return FindInternal<T>(sequence, item, comparer, pivot + 1, high);
		}
	}
}
