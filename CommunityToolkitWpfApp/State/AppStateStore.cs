using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace CommunityToolkitWpfApp.State;

public partial class AppStateStore : ObservableObject
{
    private CounterState _counterState = new();
    private ImageState _imageState = new();
    private EventsState _eventsState = new();

    public CounterState CounterState
    {
        get => _counterState;
        private set => SetProperty(ref _counterState, value);
    }

    public ImageState ImageState
    {
        get => _imageState;
        private set => SetProperty(ref _imageState, value);
    }

    public EventsState EventsState
    {
        get => _eventsState;
        private set => SetProperty(ref _eventsState, value);
    }

    public void IncrementCounter() => CounterState = CounterState with { Value = CounterState.Value + 1 };

    public void DecrementCounter() => CounterState = CounterState with { Value = CounterState.Value - 1 };

    public void IncrementGain() => ImageState = ImageState with { Gain = Clamp(ImageState.Gain + 1) };

    public void DecrementGain() => ImageState = ImageState with { Gain = Clamp(ImageState.Gain - 1) };

    public void IncrementWidth() => ImageState = ImageState with { Width = Clamp(ImageState.Width + 1) };

    public void DecrementWidth() => ImageState = ImageState with { Width = Clamp(ImageState.Width - 1) };

    public void IncrementZoom() => ImageState = ImageState with { Zoom = Clamp(ImageState.Zoom + 1) };

    public void DecrementZoom() => ImageState = ImageState with { Zoom = Clamp(ImageState.Zoom - 1) };

    public void LogEvent(string eventType, string description, string details = "")
    {
        var newEvent = new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = eventType,
            Description = description,
            Details = details
        };

        EventsState = EventsState with { Events = EventsState.Events.Insert(0, newEvent) };
    }

    public void ClearEvents() => EventsState = EventsState with { Events = EventsState.Events.Clear() };

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        StateChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? StateChanged;

    private static int Clamp(int value) => Math.Clamp(value, ImageState.MinValue, ImageState.MaxValue);
}
