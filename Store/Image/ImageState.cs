using Fluxor;

namespace FluxorWpfApp.Store.Image;

[FeatureState]
public record ImageState
{
    public int Gain { get; init; } = 50;
    public int Width { get; init; } = 50;
    public int Zoom { get; init; } = 50;
    
    public const int MinValue = 0;
    public const int MaxValue = 100;
}