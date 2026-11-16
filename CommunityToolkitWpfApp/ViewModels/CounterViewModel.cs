using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitWpfApp.Messages;
using CommunityToolkitWpfApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class CounterViewModel([FromKeyedServices(MessengerType.Weak)] IMessenger messenger) : ObservableObject
{
    [ObservableProperty]
    private int counterValue;

    [RelayCommand]
    private void Increment()
    {
        CounterValue++;
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Counter",
            Description = "Counter incremented",
            Details = "Value increased by 1"
        }));
    }

    [RelayCommand]
    private void Decrement()
    {
        CounterValue--;
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Counter",
            Description = "Counter decremented",
            Details = "Value decreased by 1"
        }));
    }
}
