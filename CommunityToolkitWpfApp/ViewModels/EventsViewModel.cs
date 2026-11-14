using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitWpfApp.Models;
using System.Collections.ObjectModel;

namespace CommunityToolkitWpfApp.ViewModels;

public partial class EventsViewModel : ObservableObject
{
    public ObservableCollection<EventLogEntry> Events { get; } = [];

    public EventsViewModel()
    {
    }

    public void LogEvent(string eventType, string description, string details = "")
    {
        Events.Insert(0, new EventLogEntry
        {
            Timestamp = DateTime.Now,
            EventType = eventType,
            Description = description,
            Details = details
        });
    }

    [RelayCommand]
    private void ClearEvents()
    {
        Events.Clear();
    }
}
