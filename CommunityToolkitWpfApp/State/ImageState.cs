namespace CommunityToolkitWpfApp.State;

public record ImageState(int Gain = 50, int Width = 50, int Zoom = 50)
{
    public const int MinValue = 0;
    public const int MaxValue = 100;
}
