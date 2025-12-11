using Fluxor;

namespace FluxorWpfApp.Store.MyLab
{
    public static class MyLabReducers
    {
        // Session Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeSessionAction(MyLabState state, ChangeSessionAction action)
        {
            return state with { Session = action.Payload };
        }

        // Scan Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeScanAction(MyLabState state, ChangeScanAction action)
        {
            return state with { Scan = action.Payload };
        }

        // Gain Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeGainAction(MyLabState state, ChangeGainAction action)
        {
            var bMode = state.BMode ?? new BModeState();
            var updatedBMode = bMode with { Gain = action.Payload };
            return state with { BMode = updatedBMode };
        }

        // Depth Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeDepthAction(MyLabState state, ChangeDepthAction action)
        {
            return state with { Depth = action.Payload };
        }

        // Frequency Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeFrequencyAction(MyLabState state, ChangeFrequencyAction action)
        {
            return state with { Frequency = action.Payload };
        }

        // Focus Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeFocusAction(MyLabState state, ChangeFocusAction action)
        {
            return state with { Focus = action.Payload };
        }

        // Dynamic Range Reducer
        [ReducerMethod]
        public static MyLabState ReduceChangeDynamicRangeAction(MyLabState state, ChangeDynamicRangeAction action)
        {
            return state with { DynamicRange = action.Payload };
        }
    }
}
