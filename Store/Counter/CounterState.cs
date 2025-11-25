using Fluxor;

namespace FluxorWpfApp.Store.Counter;

[FeatureState]
public record CounterState
{
    public int Value { get; init; }
    
    public CounterState()
    {
        Value = 0;
    }
    
    public CounterState(int value)
    {
        Value = value;
    }
}