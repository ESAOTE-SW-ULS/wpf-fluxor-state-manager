using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class CounterViewModel : ObservableObject
{
    private readonly EventsViewModel _eventsViewModel;

    [ObservableProperty]
    private int counterValue;

    public CounterViewModel(EventsViewModel eventsViewModel, [FromKeyedServices(MessengerType.Weak)] IMessenger messenger)
    {
        _eventsViewModel = eventsViewModel;

        var test = App.Services.GetRequiredKeyedService<IMessenger>(MessengerType.Weak);
        messenger.Send(new EventsViewModel());
    }

    [RelayCommand]
    private void Increment()
    {
        CounterValue++;
        _eventsViewModel.LogEvent("Counter", "Counter incremented", "Value increased by 1");
    }

    [RelayCommand]
    private void Decrement()
    {
        CounterValue--;
        _eventsViewModel.LogEvent("Counter", "Counter decremented", "Value decreased by 1");
    }
}
