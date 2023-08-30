namespace DotnetPlayground.WebApi.Exceptions;

public abstract class SampleAbstractException : Exception
{
    public SampleAbstractException(string message) : base(message)
    {
    }
}
