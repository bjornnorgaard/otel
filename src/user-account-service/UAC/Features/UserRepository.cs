using UAC.Configuration;

namespace UAC.Features;

public class UserRepository
{
    public async Task<string> GetUser(Guid id)
    {
        using var activity = Instrumentation.ActivitySource.StartActivity();
        await Task.Delay(Random.Shared.Next(250));
        return $"User {id}";
    }
}