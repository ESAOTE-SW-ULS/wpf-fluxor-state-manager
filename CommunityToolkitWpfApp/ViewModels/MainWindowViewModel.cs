using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public CounterViewModel CounterViewModel { get; }
    public ImageViewModel ImageViewModel { get; }
    public EventsViewModel EventsViewModel { get; }

    [ObservableProperty]
    private ObservableObject currentViewModel;

    public MainWindowViewModel(
        CounterViewModel counterViewModel,
        ImageViewModel imageViewModel,
        EventsViewModel eventsViewModel)
    {
        CounterViewModel = counterViewModel;
        ImageViewModel = imageViewModel;
        EventsViewModel = eventsViewModel;

        currentViewModel = CounterViewModel;
    }

    [RelayCommand]
    private void ShowCounter()
    {
        CurrentViewModel = CounterViewModel;
    }

    [RelayCommand]
    private void ShowImage()
    {
        CurrentViewModel = ImageViewModel;
    }

    [RelayCommand]
    private void ShowEvents()
    {
        CurrentViewModel = EventsViewModel;
    }
}
