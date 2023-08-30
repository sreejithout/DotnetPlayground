namespace DotnetPlayground.WebApi.Exceptions;

public class SampleNotFoundException : SampleAbstractException
{
    public SampleNotFoundException(string message) : base(message)
    {

    }
}
