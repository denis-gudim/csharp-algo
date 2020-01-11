using System;
using System.Collections.Generic;

namespace Gudim.Algo.Tests
{
    public sealed class ExpressionComparer<T, K> : IComparer<T> where K : IComparable
    {
        private readonly Func<T, K> _func;

        public ExpressionComparer(Func<T, K> func)
        {
            _func = func;
        }
        public int Compare(T x, T y)
        {
            if (x == null || y == null)
                return CompareNullPossibleObjects(x, y);

            var xValue = _func(x);
            var yValue = _func(y);

            if (xValue == null || yValue == null)
                return CompareNullPossibleObjects(xValue, yValue);

            return xValue.CompareTo(yValue);
        }

        private int CompareNullPossibleObjects(object x, object y)
        {
            if (x == null && y == null)
                return 0;

            if (x == null)
                return -1;

            return 1;
        }
    }
}