using Fluxor;
using System.Collections.Immutable;

namespace FluxorWpfApp.Store.Events;

public record EventLogEntry
{
    public DateTime Timestamp { get; init; }
    public string EventType { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Details { get; init; } = string.Empty;
}

[FeatureState]
public record EventsState
{
    public ImmutableList<EventLogEntry> Events { get; init; } = ImmutableList<EventLogEntry>.Empty;
}