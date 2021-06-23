using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemoGoodEx
{
    class Program
    {
        #region Bad Implementation based on sorting with O(NlogN)
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .OrderBy(painter => painter.EstimateCompensation(sqMeters))
                    .FirstOrDefault();
        } 
        #endregion        
        #region Bad Readability - Can't handle nulls - double the calling of estimate compensation method 
        private static IPainter FindCheapestPainterII(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .Aggregate((best, cur) =>
                        best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ?
                        best : cur);
        }
        #endregion
        #region Readability even worse - double the calling of estimate compensation method 
        private static IPainter FindCheapestPainterIII(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .Aggregate((IPainter) null, (best, cur) =>
                        best == null || 
                        best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ?
                        best : cur);
        }
        #endregion
        #region Readability is good - WithMany come with surprising behaviour
        private static IPainter FindCheapestPainterIV(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }
        #endregion
        #region Readability is good - WithManyII come with Expected behaviour - bugs free 
        private static IPainter FindCheapestPainterV(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                    .Where(painter => painter.IsAvailable)
                    .WithMinimumII(painter => painter.EstimateCompensation(sqMeters));
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
