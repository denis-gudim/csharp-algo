using System.Collections.Generic;

namespace Gudim.Algo.Search
{
	public abstract class BaseSearchStrategy : ISearchStrategy
	{
		public int Find<T>(IList<T> sequence, T item)
		{
			return Find(sequence, item, Comparer<T>.Default);
		}

		public abstract int Find<T>(IList<T> sequence, T item, IComparer<T> comparer);
	}
}