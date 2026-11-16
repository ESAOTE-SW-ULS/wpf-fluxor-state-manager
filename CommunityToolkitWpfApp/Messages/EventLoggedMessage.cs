using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkitWpfApp.Models;

namespace CommunityToolkitWpfApp.Messages;

public sealed class EventLoggedMessage : ValueChangedMessage<EventLogEntry>
{
    public EventLoggedMessage(EventLogEntry value)
        : base(value)
    {
    }
}
