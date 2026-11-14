namespace CommunityToolkitWpfApp.State;

public interface IAppAction;

public sealed class IncrementCounterAction : IAppAction;
public sealed class DecrementCounterAction : IAppAction;

public sealed class IncrementGainAction : IAppAction;
public sealed class DecrementGainAction : IAppAction;

public sealed class IncrementWidthAction : IAppAction;
public sealed class DecrementWidthAction : IAppAction;

public sealed class IncrementZoomAction : IAppAction;
public sealed class DecrementZoomAction : IAppAction;

public sealed class LogEventAction(string eventType, string description, string details = "") : IAppAction
{
    public string EventType { get; } = eventType;
    public string Description { get; } = description;
    public string Details { get; } = details;
}

public sealed class ClearEventsAction : IAppAction;
