namespace CSharpFeatures.CSharp6;

internal class ExceptionFilters
{
    public void ExceptionFilter()
    {
        try { throw new NotImplementedException(); }
        catch (Exception e) when (e.Message.Contains("hello")) { } // 1. filters the catch with when
        finally { }
    }
}
