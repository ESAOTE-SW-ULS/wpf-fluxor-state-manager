using Fluxor;
using FluxorWpfApp.Store.Counter;
using FluxorWpfApp.Store.Image;

namespace FluxorWpfApp.Store.Events;

public class EventLoggingEffects
{
    [EffectMethod]
    public Task HandleIncrementCounterAction(IncrementCounterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Counter", 
            "Counter incremented", 
            "Value increased by 1"));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleDecrementCounterAction(DecrementCounterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Counter", 
            "Counter decremented", 
            "Value decreased by 1"));
        return Task.CompletedTask;
    }

    // Gain effects
    [EffectMethod]
    public Task HandleIncrementGainAction(IncrementGainAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Gain incremented", 
            "Gain value increased by 1"));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleDecrementGainAction(DecrementGainAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Gain decremented", 
            "Gain value decreased by 1"));
        return Task.CompletedTask;
    }

    // Width effects
    [EffectMethod]
    public Task HandleIncrementWidthAction(IncrementWidthAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Width incremented", 
            "Width value increased by 1"));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleDecrementWidthAction(DecrementWidthAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Width decremented", 
            "Width value decreased by 1"));
        return Task.CompletedTask;
    }

    // Zoom effects
    [EffectMethod]
    public Task HandleIncrementZoomAction(IncrementZoomAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Zoom incremented", 
            "Zoom value increased by 1"));
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleDecrementZoomAction(DecrementZoomAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new LogEventAction(
            "Image", 
            "Zoom decremented", 
            "Zoom value decreased by 1"));
        return Task.CompletedTask;
    }
}