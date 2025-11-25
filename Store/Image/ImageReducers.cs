using Fluxor;

namespace FluxorWpfApp.Store.Image;

public static class ImageReducers
{
    private static int ClampValue(int value) => Math.Max(ImageState.MinValue, Math.Min(ImageState.MaxValue, value));

    // Gain reducers
    [ReducerMethod]
    public static ImageState ReduceIncrementGainAction(ImageState state, IncrementGainAction action) =>
        state with { Gain = ClampValue(state.Gain + 1) };

    [ReducerMethod]
    public static ImageState ReduceDecrementGainAction(ImageState state, DecrementGainAction action) =>
        state with { Gain = ClampValue(state.Gain - 1) };

    // Width reducers
    [ReducerMethod]
    public static ImageState ReduceIncrementWidthAction(ImageState state, IncrementWidthAction action) =>
        state with { Width = ClampValue(state.Width + 1) };

    [ReducerMethod]
    public static ImageState ReduceDecrementWidthAction(ImageState state, DecrementWidthAction action) =>
        state with { Width = ClampValue(state.Width - 1) };

    // Zoom reducers
    [ReducerMethod]
    public static ImageState ReduceIncrementZoomAction(ImageState state, IncrementZoomAction action) =>
        state with { Zoom = ClampValue(state.Zoom + 1) };

    [ReducerMethod]
    public static ImageState ReduceDecrementZoomAction(ImageState state, DecrementZoomAction action) =>
        state with { Zoom = ClampValue(state.Zoom - 1) };
}