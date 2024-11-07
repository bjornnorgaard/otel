

namespace UAC.Background
{
    public class TicketService(ILogger<TicketService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken st)
        {
            var i = 0;
            while (!st.IsCancellationRequested)
            {
                logger.LogInformation("Running ticket service running {TickerRunCount} times", i++);
                await Task.Delay(1000, st);
            }
        }
    }
}