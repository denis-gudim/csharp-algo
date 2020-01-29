using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gudim.Algo.Tests
{
	internal static class TestUtils
	{
		public static IEnumerable<T> GenerateTestSequence<T>(int size, Func<int, T> selector)
		{
			for (var i = 0; i < size; i++)
			{
				yield return selector(i);
			}
		}

		public static List<T> GenerateTestList<T>(int size, Func<int, T> selector)
		{
			return GenerateTestSequence(size, selector).ToList();
		}

		public static List<T> GenerateRandomTestList<T>(int size, Func<int, T> selector)
		{
			var rnd = new Random();

			return GenerateTestList(size, i => selector(rnd.Next()));
		}

		public static List<int> GenerateRandomTestList(int size)
		{
			return GenerateTestList(size, i => i);
		}
	}
}
