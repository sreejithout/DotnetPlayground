namespace CSharpFeatures.CSharp6
{
    internal class NameOfOperator
    {
        public GetterOnlyAutoProperties GetProperty(GetterOnlyAutoProperties x)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x)); // 1. nameof
            }
            return x;
        }
    }
}
