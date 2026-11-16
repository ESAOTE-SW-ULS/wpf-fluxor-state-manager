using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitWpfApp.Messages;
using CommunityToolkitWpfApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class EventsViewModel : ObservableObject, IRecipient<EventLoggedMessage>
{
    private readonly IMessenger _messenger;

    public ObservableCollection<EventLogEntry> Events { get; } = [];

    public EventsViewModel([FromKeyedServices(MessengerType.Weak)] IMessenger messenger)
    {
        _messenger = messenger;
        _messenger.Register(this);
    }

    public void Receive(EventLoggedMessage message)
    {
        Events.Insert(0, message.Value);
    }

    [RelayCommand]
    private void ClearEvents()
    {
        Events.Clear();
    }
}
