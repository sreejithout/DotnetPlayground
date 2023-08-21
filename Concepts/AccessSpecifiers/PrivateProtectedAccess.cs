namespace Concepts.AccessSpecifiers
{
    /// <summary>
    /// A class cannot be set as private protected
    /// </summary>
    internal class PrivateProtectedAccess
    {
        // accessible ???
        private protected int MyProperty { get; set; }
        private protected int MyMethod(int x)
        {
            return x;
        }
    }
}
