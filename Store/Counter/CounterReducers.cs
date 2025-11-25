using Fluxor;

namespace FluxorWpfApp.Store.Counter;

public static class CounterReducers
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
        state with { Value = state.Value + 1 };

    [ReducerMethod]
    public static CounterState ReduceDecrementCounterAction(CounterState state, DecrementCounterAction action) =>
        state with { Value = state.Value - 1 };
}