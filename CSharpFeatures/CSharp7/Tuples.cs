namespace CSharpFeatures.CSharp7;

/// <summary>
/// C# 7 improved tuple support, allowing you to name tuple elements and access them by name.
/// </summary>
internal class Tuples
{
    string BasicTuple()
    {
        var t1 = SimpleTuple(1, 5);
        return $"{t1.Item1} {t1.Item2}";
    }

    string ReceiveAsTuple()
    {
        var (a, b) = SimpleTuple(1, 5);
        return $"{a} {b}";
    }

    string ReceiveAsTupleWithDifferentTypes()
    {
        var (a, b) = DifferentTypes();
        return $"{a} {b}";
    }

    string ReceiveNamedTuple()
    {
        var t = NamedTuple();
        return $"{t.i} {t.s}";
    }

    string ReceiveNamedTupleAsTuple()
    {
        var (t1, t2) = NamedTuple();
        return $"{t1} {t2}";
    }

    #region
    (int, int) SimpleTuple(int x, int y)
    {
        return (x, y);
    }

    (int, string) DifferentTypes()
    {
        int x = 1;
        string s = "hi";
        return (x, s);
    }

    (int i, string s) NamedTuple()
    {
        int x = 1;
        string s = "hi";
        return (x, s);
    }
    #endregion
}