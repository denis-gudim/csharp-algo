using System;
using System.Collections.Generic;
using System.Linq;
using Gudim.Algo.Search;
using NUnit.Framework;

namespace Gudim.Algo.Tests
{
	[TestFixture]
	public sealed class SearchTests
	{
		private ISearchStrategy[] _searchStrategies;

		[OneTimeSetUp]
		public void Init()
		{
			_searchStrategies = new ISearchStrategy[]
			{
				new LinearSearchStrategy(),
				new BinarySearchStrategy(), 
			};
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(10000)]
		public void Find_Simple_Type_Value_Test(int size)
		{
			foreach (var strategy in _searchStrategies)
			{
				// Arrange
				var rnd = new Random();
				var	testList = Enumerable.Range(0, size)
						.Select(i => rnd.Next())
						.OrderBy(item => item)
						.ToList();
				var testItem = testList[size / 3];

				// Act
				var resultIndex= strategy.Find(testList, testItem);

				// Assert
				Assert.GreaterOrEqual(resultIndex, 0);
				Assert.Less(resultIndex, testList.Count);
				Assert.AreEqual(testItem, testList[resultIndex]);
			}
		}

		[Test]
		public void Find_Simple_Type_Value_In_Empty_List_Test()
		{
			foreach (var strategy in _searchStrategies)
			{
				// Arrange
				var testList = new List<int>();
				var testItem = 5;

				// Act
				var resultIndex = strategy.Find(testList, testItem);

				// Assert
				Assert.Less(resultIndex, 0);
			}
		}
	}
}