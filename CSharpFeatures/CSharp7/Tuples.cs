namespace CSharpFeatures.CSharp7;

internal class Tuples
{

    string callingTuples()
    {
        int invokeCondition = 1;

        switch (invokeCondition)
        {
            case 1:
                var t1 = One(1, 5);
                return $"{t1.Item1} {t1.Item2}";
            default:
                return "none";
        }

    }

    (int, int) One(int x, int y)
    {
        return (x, y);
    }
}