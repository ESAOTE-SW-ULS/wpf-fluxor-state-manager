using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitWpfApp.State;
using System.Collections.ObjectModel;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class EventsViewModel : ObservableObject, IDisposable
{
    private readonly IAppDispatcher _dispatcher;
    private readonly AppStateStore _store;

    public ObservableCollection<EventLogEntry> Events { get; } = [];

    public EventsViewModel(IAppDispatcher dispatcher, AppStateStore store)
    {
        _dispatcher = dispatcher;
        _store = store;

        _store.StateChanged += OnStateChanged;
        Refresh();
    }

    [RelayCommand]
    private void ClearEvents()
    {
        _dispatcher.Dispatch(new ClearEventsAction());
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        Events.Clear();
        foreach (var item in _store.EventsState.Events)
        {
            Events.Add(item);
        }
    }

    public void Dispose()
    {
        _store.StateChanged -= OnStateChanged;
    }
}
