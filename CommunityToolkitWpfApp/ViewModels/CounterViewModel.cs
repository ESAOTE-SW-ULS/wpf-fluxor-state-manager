using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class CounterViewModel : ObservableObject
{
    private readonly EventsViewModel _eventsViewModel;

    [ObservableProperty]
    private int counterValue;

    public CounterViewModel(EventsViewModel eventsViewModel)
    {
        _eventsViewModel = eventsViewModel;
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
