using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CommunityToolkitWpfApp.State;

public interface IAppDispatcher
{
    void Dispatch(IAppAction action);
}

public sealed class ActionDispatchedMessage(IAppAction value) : ValueChangedMessage<IAppAction>(value);

public sealed class AppDispatcher : IAppDispatcher
{
    private readonly IMessenger _messenger;
    private readonly AppStateStore _store;

    public AppDispatcher(IMessenger messenger, AppStateStore store)
    {
        _messenger = messenger;
        _store = store;

        _messenger.Register<AppDispatcher, ActionDispatchedMessage>(this, static (recipient, message) =>
        {
            recipient.Handle(message.Value);
        });
    }

    public void Dispatch(IAppAction action)
    {
        _messenger.Send(new ActionDispatchedMessage(action));
    }

    private void Handle(IAppAction action)
    {
        switch (action)
        {
            case IncrementCounterAction:
                _store.IncrementCounter();
                _store.LogEvent("Counter", "Counter incremented", "Value increased by 1");
                break;
            case DecrementCounterAction:
                _store.DecrementCounter();
                _store.LogEvent("Counter", "Counter decremented", "Value decreased by 1");
                break;
            case IncrementGainAction:
                _store.IncrementGain();
                _store.LogEvent("Image", "Gain incremented", "Gain value increased by 1");
                break;
            case DecrementGainAction:
                _store.DecrementGain();
                _store.LogEvent("Image", "Gain decremented", "Gain value decreased by 1");
                break;
            case IncrementWidthAction:
                _store.IncrementWidth();
                _store.LogEvent("Image", "Width incremented", "Width value increased by 1");
                break;
            case DecrementWidthAction:
                _store.DecrementWidth();
                _store.LogEvent("Image", "Width decremented", "Width value decreased by 1");
                break;
            case IncrementZoomAction:
                _store.IncrementZoom();
                _store.LogEvent("Image", "Zoom incremented", "Zoom value increased by 1");
                break;
            case DecrementZoomAction:
                _store.DecrementZoom();
                _store.LogEvent("Image", "Zoom decremented", "Zoom value decreased by 1");
                break;
            case LogEventAction logEventAction:
                _store.LogEvent(logEventAction.EventType, logEventAction.Description, logEventAction.Details);
                break;
            case ClearEventsAction:
                _store.ClearEvents();
                break;
        }
    }
}
