namespace Rectangles;

public record struct RectangleInfo(long Number, List<RectanglePair> Dimensions)
{
    public readonly bool IsRectangle => Dimensions.Count > 0;
}
