using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class ImageViewModel : ObservableObject
{
    private readonly EventsViewModel _eventsViewModel;

    private const int MinValue = 0;
    private const int MaxValue = 100;

    [ObservableProperty]
    private int gain = 50;

    [ObservableProperty]
    private int width = 50;

    [ObservableProperty]
    private int zoom = 50;

    public ImageViewModel(EventsViewModel eventsViewModel)
    {
        _eventsViewModel = eventsViewModel;
    }

    [RelayCommand(CanExecute = nameof(CanIncrementGain))]
    private void IncrementGain()
    {
        Gain = Math.Min(MaxValue, Gain + 1);
        _eventsViewModel.LogEvent("Image", "Gain incremented", "Gain value increased by 1");
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementGain))]
    private void DecrementGain()
    {
        Gain = Math.Max(MinValue, Gain - 1);
        _eventsViewModel.LogEvent("Image", "Gain decremented", "Gain value decreased by 1");
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanIncrementWidth))]
    private void IncrementWidth()
    {
        Width = Math.Min(MaxValue, Width + 1);
        _eventsViewModel.LogEvent("Image", "Width incremented", "Width value increased by 1");
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementWidth))]
    private void DecrementWidth()
    {
        Width = Math.Max(MinValue, Width - 1);
        _eventsViewModel.LogEvent("Image", "Width decremented", "Width value decreased by 1");
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanIncrementZoom))]
    private void IncrementZoom()
    {
        Zoom = Math.Min(MaxValue, Zoom + 1);
        _eventsViewModel.LogEvent("Image", "Zoom incremented", "Zoom value increased by 1");
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementZoom))]
    private void DecrementZoom()
    {
        Zoom = Math.Max(MinValue, Zoom - 1);
        _eventsViewModel.LogEvent("Image", "Zoom decremented", "Zoom value decreased by 1");
        RefreshCommandStates();
    }

    private bool CanIncrementGain() => Gain < MaxValue;
    private bool CanDecrementGain() => Gain > MinValue;
    private bool CanIncrementWidth() => Width < MaxValue;
    private bool CanDecrementWidth() => Width > MinValue;
    private bool CanIncrementZoom() => Zoom < MaxValue;
    private bool CanDecrementZoom() => Zoom > MinValue;

    partial void OnGainChanged(int value)
    {
        RefreshCommandStates();
    }

    partial void OnWidthChanged(int value)
    {
        RefreshCommandStates();
    }

    partial void OnZoomChanged(int value)
    {
        RefreshCommandStates();
    }

    private void RefreshCommandStates()
    {
        IncrementGainCommand.NotifyCanExecuteChanged();
        DecrementGainCommand.NotifyCanExecuteChanged();
        IncrementWidthCommand.NotifyCanExecuteChanged();
        DecrementWidthCommand.NotifyCanExecuteChanged();
        IncrementZoomCommand.NotifyCanExecuteChanged();
        DecrementZoomCommand.NotifyCanExecuteChanged();
    }
}
