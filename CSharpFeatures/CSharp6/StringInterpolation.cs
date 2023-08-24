namespace CSharpFeatures.CSharp6;

internal class StringInterpolation
{
    public int X { get; set; }
    public int Y { get; set; }

    public StringInterpolation(int x, int y)
    {
        X = x;
        Y = y;
    }

    public string Interpolated()
    {
        return $"{X} {Y}"; // 1. this is how we interpolate the strings
    }
}
