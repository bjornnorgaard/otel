using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace UAC.Configuration;

public static class Instrumentation
{
    public const string ServiceName = "UserAccountService";
    public static readonly ActivitySource ActivitySource = new(ServiceName);
    public static readonly Meter Meter = new(ServiceName);
}
