using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemoGoodEx
{
    public static class EnumerableExtensions
    {
        #region Easy to read but calling criterion method twice which come with surprising behaviour - Not good
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence.Aggregate((T)null,
                    (best, cur) =>
                       best == null ||
                       criterion(cur).CompareTo(criterion(best)) < 0 ?
                       cur : best
                    );
        #endregion
        #region Hard to read but criterion method once which come with Expected behaviour - good to use
        public static T WithMinimumII<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
                sequence
                  .Select(obj => Tuple.Create(obj, criterion(obj)))
                  .Aggregate((Tuple<T, TKey>)null,
                    (best, cur) =>
                       best == null ||
                       cur.Item2.CompareTo(best.Item2) < 0 ?
                       cur : best
                    ).Item1; 
        #endregion
    }
}
