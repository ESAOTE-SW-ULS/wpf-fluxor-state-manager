namespace CommunityToolkitWpfApp.Models;

public record EventLogEntry
{
    public DateTime Timestamp { get; init; }
    public string EventType { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Details { get; init; } = string.Empty;
}
