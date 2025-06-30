var results = LongRange(1, 100)
    .Select(RectangleUtils.GetRectangleInfo)
    .Where(info => info.IsRectangle);

foreach (var info in results)
{
    Console.WriteLine($"{info.Number} can form rectangle(s): {string.Join(", ", info.Dimensions.Select(d => $"{d.Width}x{d.Height}"))}");
}

static IEnumerable<long> LongRange(long start, long count)
{
    for (var i = start; i < start + count; i++)
    {
        yield return i;
    }
}

public record struct RectanglePair(long Width, long Height);

public record struct RectangleInfo(long Number, List<RectanglePair> Dimensions)
{
    public readonly bool IsRectangle => Dimensions.Count > 0;
}

public static class RectangleUtils
{
    public static RectangleInfo GetRectangleInfo(long n)
    {
        var dimensions = new List<RectanglePair>();
        for (long w = 2; w * w <= n; w++)
        {
            if (n % w == 0)
            {
                var h = n / w;
                if (h >= 2 && h != w)
                {
                    dimensions.Add(new RectanglePair(w, h));
                }
            }
        }
        return new RectangleInfo(n, dimensions);
    }
}
