using Fluxor;

namespace FluxorWpfApp.Store.Events;

public static class EventsReducers
{
    [ReducerMethod]
    public static EventsState ReduceLogEventAction(EventsState state, LogEventAction action)
    {
        var newEvent = new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = action.EventType,
            Description = action.Description,
            Details = action.Details
        };
        
        return state with { Events = state.Events.Insert(0, newEvent) };
    }

    [ReducerMethod]
    public static EventsState ReduceClearEventsAction(EventsState state, ClearEventsAction action) =>
        state with { Events = state.Events.Clear() };
}