using System.ComponentModel.DataAnnotations;

namespace UAC.Options;

public class ServiceOptions
{
    [Required] public required string TelemetryHost { get; set; }
}