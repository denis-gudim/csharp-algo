using System;
using System.Linq;
using NUnit.Framework;

namespace Gudim.Algo.Sort.UnitTests
{
    [TestFixture]
    public sealed class BubbleSortingStrategyTests
    {
        [TestCase(typeof(BubbleSortingStrategy), new[] { 0, 1, 2, 999,1000})]
        public void Sort_Simple_Type_Values_Test(Type strategyType, int[] testListSizes)
        {
            foreach (var size in testListSizes)
            {
                // Arrange
                var strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);
                var rnd = new Random();
                var testList = Enumerable.Range(0, size)
                    .Select(i => rnd.Next())
                    .ToList();
                var referenceList = testList.OrderBy(item => item).ToList();

                // Act
                strategy.Sort(testList);

                // Assert
                CollectionAssert.AreEqual(testList, referenceList);
            }
        }

        [TestCase(typeof(BubbleSortingStrategy), new[] { 0, 1, 2, 1000 })]
        public void Sort_Nullable_Type_Values_Test(Type strategyType, int[] testListSizes)
        {
            foreach (var size in testListSizes)
            {
                // Arrange
                var strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);
                var rnd = new Random();
                var testList = Enumerable.Range(0, size)
                    .Select(i => (int?)rnd.Next())
                    .ToList();
                testList.Add(null);
                var referenceList = testList.OrderBy(item => item).ToList();

                // Act
                strategy.Sort(testList);

                // Assert
                CollectionAssert.AreEqual(testList, referenceList);
            }
        }

        [TestCase(typeof(BubbleSortingStrategy), new[] { 0, 1, 2, 1000 })]
        public void Sort_With_Custom_Comparer_Test(Type strategyType, int[] testListSizes)
        {
            foreach (var size in testListSizes)
            {
                // Arrange
                var strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);
                var rnd = new Random();
                var testList = Enumerable.Range(0, size)
                    .Select(i => new SortingItem { Value = rnd.Next() })
                    .ToList();
                var comparer = new ExpressionComparer<SortingItem, int>(item => item.Value);
                var referenceList = testList.OrderBy(item => item, comparer).ToList();

                // Act
                strategy.Sort(testList, comparer);

                // Assert
                CollectionAssert.AreEqual(testList, referenceList);
            }
        }
    }
}