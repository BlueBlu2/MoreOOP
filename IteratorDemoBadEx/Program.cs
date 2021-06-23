using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorDemoBadEx
{
    class Program
    {
        private static IPainter FindCheapestPainter( double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = double.MaxValue;
            IPainter cheapest = null;
            foreach (IPainter painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        bestPrice = price;
                        cheapest = painter;
                    }
                }
            }
            return cheapest;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
