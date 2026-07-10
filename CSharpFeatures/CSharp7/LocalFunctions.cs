namespace CSharpFeatures.CSharp7;

internal class LocalFunctions
{
    /// <summary>
    /// Local functions allow you to define functions inside another function.
    /// They are useful for organizing and encapsulating code that is only called from one location.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int AddWithLocalFunction(int a, int b)
    {
        return Add(a,b);

        int Add(int a, int b) {  return a + b; }
    }
}
