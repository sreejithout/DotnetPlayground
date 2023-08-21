namespace Concepts.AccessSpecifiers
{
    /// <summary>
    /// A class cannot be set as private
    /// </summary>
    internal class PrivateAccess
    {
        // accessible only inside this class 
        private int MyProperty { get; set; }
        private int MyMethod(int x)
        {
            return x;
        }
    }
}
