using System.ComponentModel.DataAnnotations;

namespace UAC.Options;

public class ServiceOptions
{
    [Required] public string ServiceName { get; set; }
    [Required] public string TelemetryHost { get; set; }
}