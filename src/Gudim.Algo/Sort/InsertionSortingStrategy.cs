using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
	public sealed class InsertionSortingStrategy : BaseSortingStrategy
	{
		public override void Sort<T>(IList<T> collection, IComparer<T> comparer)
		{
			var size = collection.Count;

			for (var i = 1; i < size; i++)
			{
				var j = i - 1;
				var item = collection[i];

				while (j >= 0 && comparer.Compare(collection[j], item) > 0)
				{
					collection[j + 1] = collection[j];
					collection[j] = item;

					j--;
				}
			}
		}
	}
}
