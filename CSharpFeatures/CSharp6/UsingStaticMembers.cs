using static System.Math; // . this is the feature we are discussing here
namespace CSharpFeatures.CSharp6
{
    internal class UsingStaticMembers
    {
        public double MyProperty
        {
            get { return Sqrt(4); } // 2. it enables to shorten the Sqrt invokation here for example.
        }
    }
}
