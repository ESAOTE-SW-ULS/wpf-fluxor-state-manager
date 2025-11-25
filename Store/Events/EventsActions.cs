namespace FluxorWpfApp.Store.Events;

public class LogEventAction
{
    public string EventType { get; }
    public string Description { get; }
    public string Details { get; }
    
    public LogEventAction(string eventType, string description, string details = "")
    {
        EventType = eventType;
        Description = description;
        Details = details;
    }
}

public class ClearEventsAction
{
}