using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitWpfApp.State;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class ImageViewModel : ObservableObject, IDisposable
{
    private readonly IAppDispatcher _dispatcher;
    private readonly AppStateStore _store;

    [ObservableProperty]
    private int gain;

    [ObservableProperty]
    private int width;

    [ObservableProperty]
    private int zoom;

    public ImageViewModel(IAppDispatcher dispatcher, AppStateStore store)
    {
        _dispatcher = dispatcher;
        _store = store;

        _store.StateChanged += OnStateChanged;
        Refresh();
    }

    [RelayCommand(CanExecute = nameof(CanIncrementGain))]
    private void IncrementGain()
    {
        _dispatcher.Dispatch(new IncrementGainAction());
    }

    [RelayCommand(CanExecute = nameof(CanDecrementGain))]
    private void DecrementGain()
    {
        _dispatcher.Dispatch(new DecrementGainAction());
    }

    [RelayCommand(CanExecute = nameof(CanIncrementWidth))]
    private void IncrementWidth()
    {
        _dispatcher.Dispatch(new IncrementWidthAction());
    }

    [RelayCommand(CanExecute = nameof(CanDecrementWidth))]
    private void DecrementWidth()
    {
        _dispatcher.Dispatch(new DecrementWidthAction());
    }

    [RelayCommand(CanExecute = nameof(CanIncrementZoom))]
    private void IncrementZoom()
    {
        _dispatcher.Dispatch(new IncrementZoomAction());
    }

    [RelayCommand(CanExecute = nameof(CanDecrementZoom))]
    private void DecrementZoom()
    {
        _dispatcher.Dispatch(new DecrementZoomAction());
    }

    private bool CanIncrementGain() => Gain < ImageState.MaxValue;
    private bool CanDecrementGain() => Gain > ImageState.MinValue;
    private bool CanIncrementWidth() => Width < ImageState.MaxValue;
    private bool CanDecrementWidth() => Width > ImageState.MinValue;
    private bool CanIncrementZoom() => Zoom < ImageState.MaxValue;
    private bool CanDecrementZoom() => Zoom > ImageState.MinValue;

    private void OnStateChanged(object? sender, EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        var state = _store.ImageState;

        Gain = state.Gain;
        Width = state.Width;
        Zoom = state.Zoom;

        IncrementGainCommand.NotifyCanExecuteChanged();
        DecrementGainCommand.NotifyCanExecuteChanged();
        IncrementWidthCommand.NotifyCanExecuteChanged();
        DecrementWidthCommand.NotifyCanExecuteChanged();
        IncrementZoomCommand.NotifyCanExecuteChanged();
        DecrementZoomCommand.NotifyCanExecuteChanged();
    }

    public void Dispose()
    {
        _store.StateChanged -= OnStateChanged;
    }
}
