namespace UAC.Extensions;

public static class OptionsExtensions
{
    /// <summary>
    /// Use this method to register options in the WebApplicationBuilder.
    /// Then you can use the BindOptions method to bind the options to the configuration.
    /// </summary>
    /// <param name="builder"></param>
    /// <typeparam name="T"></typeparam>
    public static void RegisterOptions<T>(this WebApplicationBuilder builder) where T : class
    {
        builder.Services.AddOptions<T>()
            .BindConfiguration(typeof(T).Name)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

    /// <summary>
    /// First register the options in the WebApplicationBuilder using the RegisterOptions method.
    /// Then use this method to bind the options to the configuration.
    /// </summary>
    /// <param name="configuration"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T BindOptions<T>(this IConfiguration configuration)
    {
        var optionsType = Activator.CreateInstance<T>();
        configuration.GetSection(typeof(T).Name).Bind(optionsType);
        return optionsType;
    }
}