using System.Collections.Generic;

namespace Gudim.Algo.Sort
{
	public interface IQuickSortingPartitionStrategy
	{
		int Partition<T>(IList<T> collection, IComparer<T> comparer, int low, int high);
	}
}