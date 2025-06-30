using Rectangles;

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
