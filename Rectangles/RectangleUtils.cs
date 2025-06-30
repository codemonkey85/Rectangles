namespace Rectangles;

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

