using System;
using System.Collections.Generic;

namespace Gudim.Algo.Search
{
	public sealed class LinearSearchStrategy : BaseSearchStrategy
	{
		public override int Find<T>(IList<T> sequence, T item, IComparer<T> comparer)
		{
			var size = sequence.Count;

			for (var i = 0; i < size; i++)
			{
				if (comparer.Compare(item, sequence[i]) == 0)
					return i;
			}

			return -1;
		}
	}
}