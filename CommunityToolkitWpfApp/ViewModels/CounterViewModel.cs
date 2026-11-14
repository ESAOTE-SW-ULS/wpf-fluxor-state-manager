using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitWpfApp.State;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class CounterViewModel : ObservableObject, IDisposable
{
    private readonly IAppDispatcher _dispatcher;
    private readonly AppStateStore _store;

    [ObservableProperty]
    private int counterValue;

    public CounterViewModel(IAppDispatcher dispatcher, AppStateStore store)
    {
        _dispatcher = dispatcher;
        _store = store;

        _store.StateChanged += OnStateChanged;
        Refresh();
    }

    [RelayCommand]
    private void Increment()
    {
        _dispatcher.Dispatch(new IncrementCounterAction());
    }

    [RelayCommand]
    private void Decrement()
    {
        _dispatcher.Dispatch(new DecrementCounterAction());
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        CounterValue = _store.CounterState.Value;
    }

    public void Dispose()
    {
        _store.StateChanged -= OnStateChanged;
    }
}
