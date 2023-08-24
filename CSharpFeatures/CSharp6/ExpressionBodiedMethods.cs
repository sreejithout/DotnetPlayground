namespace CSharpFeatures.CSharp6;

internal class ExpressionBodiedMethods
{
    public int X { get; set; }
    public int Y { get; set; }

    public ExpressionBodiedMethods(int x, int y)
    {
        X = x;
        Y = y;
    }

    public string ExpressionBodied() => $"{X} {Y}"; // 1. this is how we write expression bodied methods
}
