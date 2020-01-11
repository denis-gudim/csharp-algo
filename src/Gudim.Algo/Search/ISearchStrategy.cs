using System.Collections.Generic;

namespace Gudim.Algo.Search
{
	public interface ISearchStrategy
	{
		int Find<T>(IList<T> sequence, T item);
		int Find<T>(IList<T> sequence, T item, IComparer<T> comparer);
	}
}