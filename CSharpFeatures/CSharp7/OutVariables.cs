namespace CSharpFeatures.CSharp7;

internal class OutVariables
{
    /// <summary>
    /// Out variables allow you to declare variables right at the point where they are passed as out parameters.
    /// </summary>
    public void OutVariableExample()
    {
        if(int.TryParse("5", out int i))
        {
            Console.WriteLine($"Parsed Number: {i}");
        }
    }
}
