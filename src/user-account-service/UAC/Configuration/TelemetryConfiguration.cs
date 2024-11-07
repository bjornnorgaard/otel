using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using UAC.Extensions;
using UAC.Options;

namespace UAC.Configuration;

public static class TelemetryConfiguration
{
    public static void AddTelemetry(this WebApplicationBuilder builder)
    {
        var serviceOptions = builder.Configuration.BindOptions<ServiceOptions>();
        var collectorUri = new Uri(serviceOptions.TelemetryHost);

        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(Instrumentation.ServiceName))
            .WithTracing(tracing => tracing
                .AddSource(Instrumentation.ActivitySource.Name)
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(o => o.Endpoint = collectorUri))
            .WithMetrics(metrics => metrics
                .AddMeter(Instrumentation.Meter.Name)
                .AddAspNetCoreInstrumentation()
                .AddRuntimeInstrumentation()
                .AddOtlpExporter(o => o.Endpoint = collectorUri))
            .WithLogging(logging => logging
                    .AddOtlpExporter(o => o.Endpoint = collectorUri), loggingOptions =>
                {
                    loggingOptions.IncludeScopes = true;
                    loggingOptions.IncludeFormattedMessage = true;
                }
            );
    }
}