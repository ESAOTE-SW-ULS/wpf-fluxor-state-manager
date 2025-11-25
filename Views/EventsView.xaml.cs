using System;
using System.Windows;
using System.Windows.Controls;
using Fluxor;
using FluxorWpfApp.Store.Events;

namespace FluxorWpfApp.Views;

public partial class EventsView : UserControl
{
    private readonly IDispatcher _dispatcher;
    private readonly IState<EventsState> _eventsState;

    public EventsView(IDispatcher dispatcher, IState<EventsState> eventsState)
    {
        InitializeComponent();
        
        _dispatcher = dispatcher;
        _eventsState = eventsState;
        
        _eventsState.StateChanged += OnEventsStateChanged;
        UpdateUI();
    }

    private void OnEventsStateChanged(object? sender, EventArgs e)
    {
        Dispatcher.Invoke(UpdateUI);
    }

    private void UpdateUI()
    {
        EventsDataGrid.ItemsSource = _eventsState.Value.Events;
    }

    private void ClearEventsButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new ClearEventsAction());
    }
}