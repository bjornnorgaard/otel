using System.Diagnostics;
using UAC.Configuration;

namespace UAC.Background
{
    public class TickerService(ILogger<TickerService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken st)
        {
            var i = 0;
            while (!st.IsCancellationRequested)
            {
                using (Instrumentation.ActivitySource.StartActivity())
                {
                    logger.LogInformation("Running ticket service running {TickerRunCount} times", i++);
                    await Task.Delay(10000, st);
                }
            }
        }
    }
}