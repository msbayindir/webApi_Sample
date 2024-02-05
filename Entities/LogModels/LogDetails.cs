using System.Text.Json;

namespace Entities.LogModels;

public class LogDetails
{
    public object? ModelName { get; set; }
    public object? Controller { get; set; }
    public object? Action { get; set; }
    public object? Id { get; set; }
    public object? CreatedAt { get; set; }

    public LogDetails()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public override string ToString() => JsonSerializer.Serialize(this);

}