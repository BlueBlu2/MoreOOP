using System;

namespace IteratorDemoBadEx
{
    public interface IPainter
    {
        bool IsAvailable { get;}
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}
