namespace CSharpFeatures.CSharp6;

internal class AwaitInCatchAndFinally
{
    public async void ExceptionFilter()
    {
        try { throw new NotImplementedException(); }
        catch (Exception e) when (e.Message.Contains("hello"))
        {
            await LogAsync(); // 1. await in catch
        }
        finally
        {
            await CloseAsync(); // 1. await in finally
        }
    }

    private Task CloseAsync()
    {
        throw new NotImplementedException();
    }

    private Task LogAsync()
    {
        throw new NotImplementedException();
    }
}
