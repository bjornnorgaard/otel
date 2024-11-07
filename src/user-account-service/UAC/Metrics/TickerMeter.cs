using System.Diagnostics.Metrics;
using UAC.Configuration;

namespace UAC.Metrics;

public static class TickerMeter
{
    private static readonly Counter<int> Counter =
        Instrumentation.Meter.CreateCounter<int>("Ticks", "Count", "Number of ticks recorded");

    public static void RecordTick()
    {
        Counter.Add(1);
    }
}