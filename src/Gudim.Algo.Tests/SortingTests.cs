using System.Linq;
using Gudim.Algo.Sort;
using NUnit.Framework;

namespace Gudim.Algo.Tests
{
	[TestFixture]
	public sealed class SortingTests
	{
		private ISortingStrategy[] _sortingStrategies;

		[OneTimeSetUp]
		public void Init()
		{
			_sortingStrategies = new ISortingStrategy[]
			{
				new BubbleSortingStrategy(),
				new LomutoQuickSortingStrategy(),
				new HoareQuickSortingStrategy(), 
				new InsertionSortingStrategy(), 
			};
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(999)]
		[TestCase(10000)]
		public void Sort_Simple_Type_Values_Test(int size)
		{
			foreach (var strategy in _sortingStrategies)
			{
				// Arrange
				var testList = TestUtils.GenerateRandomTestList(size);
				var referenceList = testList.OrderBy(item => item).ToList();

				// Act
				strategy.Sort(testList);

				// Assert
				CollectionAssert.AreEqual(referenceList, testList);
			}
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(999)]
		[TestCase(10000)]
		public void Sort_Nullable_Type_Values_Test(int size)
		{
			foreach (var strategy in _sortingStrategies)
			{
				// Arrange
				var testList = TestUtils.GenerateRandomTestList(size, i => (int?) i);
				testList.Add(null);
				var referenceList = testList.OrderBy(item => item).ToList();

				// Act
				strategy.Sort(testList);

				// Assert
				CollectionAssert.AreEqual(referenceList, testList);
			}
		}

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(999)]
		[TestCase(10000)]
		public void Sort_With_Custom_Comparer_Test(int size)
		{
			foreach (var strategy in _sortingStrategies)
			{
				// Arrange
				var testList = TestUtils.GenerateRandomTestList(size, i => new ExpressionComparableItem {Value = i});
				var comparer = new ExpressionComparer<ExpressionComparableItem, int>(item => item.Value);
				var referenceList = testList.OrderBy(item => item, comparer).ToList();

				// Act
				strategy.Sort(testList, comparer);

				// Assert
				CollectionAssert.AreEqual(referenceList, testList);
			}
		}
	}
}