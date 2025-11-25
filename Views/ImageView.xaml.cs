using System;
using System.Windows;
using System.Windows.Controls;
using Fluxor;
using FluxorWpfApp.Store.Image;
using Microsoft.Extensions.DependencyInjection;

namespace FluxorWpfApp.Views;

public partial class ImageView : UserControl
{
    private readonly IDispatcher _dispatcher;
    private readonly IState<ImageState> _imageState;

    public ImageView(IDispatcher dispatcher, IState<ImageState> imageState)
    {
        InitializeComponent();
        
        _dispatcher = dispatcher;
        _imageState = imageState;
        
        _imageState.StateChanged += OnImageStateChanged;
        UpdateUI();
    }

    private void OnImageStateChanged(object? sender, EventArgs e)
    {
        Dispatcher.Invoke(UpdateUI);
    }

    private void UpdateUI()
    {
        var state = _imageState.Value;
        
        // Update values
        GainValue.Text = state.Gain.ToString();
        WidthValue.Text = state.Width.ToString();
        ZoomValue.Text = state.Zoom.ToString();
        
        // Update button states based on min/max values
        GainDecrementButton.IsEnabled = state.Gain > ImageState.MinValue;
        GainIncrementButton.IsEnabled = state.Gain < ImageState.MaxValue;
        
        WidthDecrementButton.IsEnabled = state.Width > ImageState.MinValue;
        WidthIncrementButton.IsEnabled = state.Width < ImageState.MaxValue;
        
        ZoomDecrementButton.IsEnabled = state.Zoom > ImageState.MinValue;
        ZoomIncrementButton.IsEnabled = state.Zoom < ImageState.MaxValue;
    }

    // Gain button handlers
    private void GainIncrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new IncrementGainAction());
    }

    private void GainDecrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new DecrementGainAction());
    }

    // Width button handlers
    private void WidthIncrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new IncrementWidthAction());
    }

    private void WidthDecrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new DecrementWidthAction());
    }

    // Zoom button handlers
    private void ZoomIncrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new IncrementZoomAction());
    }

    private void ZoomDecrementButton_Click(object sender, RoutedEventArgs e)
    {
        _dispatcher.Dispatch(new DecrementZoomAction());
    }
}