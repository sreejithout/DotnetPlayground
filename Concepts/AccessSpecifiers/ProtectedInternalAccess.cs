namespace Concepts.AccessSpecifiers
{
    /// <summary>
    /// A class cannot be set as protected internal
    /// </summary>
    internal class ProtectedInternalAccess
    {
        // accessible inside this dll (assembly)
        // & derived class in this and other dlls (assembly)
        protected internal int MyProperty { get; set; }
        protected internal int MyMethod(int x)
        {
            return x;
        }
    }
}
