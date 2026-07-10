namespace CSharpFeatures.CSharp7;

internal class DigitSeparators
{
    /// <summary>
    /// C# 7 allows the use of underscores in numeric literals to enhance readability.
    /// </summary>
    public void DigitSeparatorExample()
    {
        int[] numbers = { 0b1, 0b_10, 0b1 - 0000, 32____000 }; // digit separators
    }
}
