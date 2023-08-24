namespace CSharpFeatures.CSharp6;

public class GetterOnlyAutoProperties
{
    public int X { get; } = 5; // here are two features. One is using get only. next one is setting the initial value here itself.

    public GetterOnlyAutoProperties(int x)
    {
        X = x;
    }
}
