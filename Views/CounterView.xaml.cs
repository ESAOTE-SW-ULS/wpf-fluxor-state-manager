using System;
using System.Windows;
using System.Windows.Controls;
using Fluxor;
using FluxorWpfApp.Store.Counter;
using Microsoft.Extensions.DependencyInjection;

namespace FluxorWpfApp.Views;

public partial class CounterView : UserControl
{
    private readonly IDispatcher _dispatcher;
    private readonly IState<CounterState> _counterState;

    public CounterView(IDispatcher dispatcher, IState<CounterState> counterState)
    {
        InitializeComponent();
        
        _dispatcher = dispatcher;
        _counterState = counterState;
        
        _counterState.StateChanged += OnCounterStateChanged;
        UpdateUI();
    }

    private void OnCounterStateChanged(object? sender, EventArgs e)
    {
        Dispatcher.Invoke(UpdateUI);
    }

    private void UpdateUI()
    {
        CounterValue.Text = _counterState.Value.Value.ToString();
    }

    private void IncrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new IncrementCounterAction());
    }

    private void DecrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new DecrementCounterAction());
    }
}