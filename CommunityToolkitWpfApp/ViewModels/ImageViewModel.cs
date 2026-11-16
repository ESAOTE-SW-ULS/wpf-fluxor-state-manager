using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkitWpfApp.Messages;
using CommunityToolkitWpfApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class ImageViewModel([FromKeyedServices(MessengerType.Weak)] IMessenger messenger) : ObservableObject
{
    private const int MinValue = 0;
    private const int MaxValue = 100;

    [ObservableProperty]
    private int gain = 50;

    [ObservableProperty]
    private int width = 50;

    [ObservableProperty]
    private int zoom = 50;

    [RelayCommand(CanExecute = nameof(CanIncrementGain))]
    private void IncrementGain()
    {
        Gain = Math.Min(MaxValue, Gain + 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Gain incremented",
            Details = "Gain value increased by 1"
        }));
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementGain))]
    private void DecrementGain()
    {
        Gain = Math.Max(MinValue, Gain - 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Gain decremented",
            Details = "Gain value decreased by 1"
        }));
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanIncrementWidth))]
    private void IncrementWidth()
    {
        Width = Math.Min(MaxValue, Width + 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Width incremented",
            Details = "Width value increased by 1"
        }));
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementWidth))]
    private void DecrementWidth()
    {
        Width = Math.Max(MinValue, Width - 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Width decremented",
            Details = "Width value decreased by 1"
        }));
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanIncrementZoom))]
    private void IncrementZoom()
    {
        Zoom = Math.Min(MaxValue, Zoom + 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Zoom incremented",
            Details = "Zoom value increased by 1"
        }));
        RefreshCommandStates();
    }

    [RelayCommand(CanExecute = nameof(CanDecrementZoom))]
    private void DecrementZoom()
    {
        Zoom = Math.Max(MinValue, Zoom - 1);
        messenger.Send(new EventLoggedMessage(new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = "Image",
            Description = "Zoom decremented",
            Details = "Zoom value decreased by 1"
        }));
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
