namespace Concepts.AccessSpecifiers
{
    /// <summary>
    /// A class cannot be set as protected
    /// </summary>
    internal class ProtectedAccess
    {
        // accessible only inside this class & derived class in this and other dlls (assembly)
        protected int MyProperty { get; set; }
        protected int MyMethod(int x)
        {
            return x;
        }
    }
}
