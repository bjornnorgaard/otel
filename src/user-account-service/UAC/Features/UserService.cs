using UAC.Configuration;

namespace UAC.Features;

public class UserService(UserRepository userRepository)
{
    public async Task<string> GetUser(Guid id)
    {
        using var activity = Instrumentation.ActivitySource.StartActivity();
        await Task.Delay(Random.Shared.Next(500));
        var user = await userRepository.GetUser(id);
        await Task.Delay(Random.Shared.Next(500));
        return user;
    }
}