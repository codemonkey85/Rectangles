// Top-level code
var results = Enumerable.Range(1, 100)
    .Select(RectangleUtils.GetRectangleInfo)
    .Where(info => info.IsRectangle);

foreach (var info in results)
{
    Console.WriteLine($"{info.Number} can form rectangle(s): {string.Join(", ", info.Dimensions.Select(d => $"{d.Width}x{d.Height}"))}");
}


public record struct RectanglePair(int Width, int Height);

public record struct RectangleInfo(int Number, List<RectanglePair> Dimensions)
{
    public readonly bool IsRectangle => Dimensions.Count > 0;
}

public static class RectangleUtils
{
    public static RectangleInfo GetRectangleInfo(int n)
    {
        var dimensions = Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
            .Where(w => n % w == 0)
            .Select(w => new RectanglePair(w, n / w))
            .Where(pair => pair.Height >= 2 && pair.Width != pair.Height)
            .ToList();

        return new RectangleInfo(n, dimensions);
    }
}
