# Dotnet Playground
## .NET 6 api solution to learn the fundamentals step by step

1. [Based on .NET 6](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
    - Created solution with open api(swagger) without docker support

2. In-built logger is used now with **seq** to visualize the logs
    - [.NET 6 Default Log](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0)
    - [Logging with iLogger Best Practices](https://blog.rsuter.com/logging-with-ilogger-recommendations-and-best-practices/)
    - Seq is a centralized log file with superpowers.
    - [https://datalust.co/seq](https://datalust.co/seq)
    ```batch
    docker pull datalust/seq
    docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
    ```
3. Layering (Trying a Clean Architecture here)
    - Business Logic Layer **DotnetPlayground.BLL**
        - Interfaces (even the one's for Repositories)
        - Models
        - DTOs
        - Enums
    - Data Access Layer **DotnetPlayground.DAL**
    - as per dependency inversion or clean architecture level, we are going to move the interfaces for the the repositories to BLL layer. Means, we will be referencing BLL from DAL and not other way around.

4. Dependency Injection
    - [built-in DI provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0)
    - [.NET 5 DI](https://www.youtube.com/watch?v=0x2KW-dJDQU)
    - Here, I'm using [Autofac](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html)

5. [Configurations](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0)

6. [Routing](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-6.0)

7. Model Binding

8. Http Client 
    - [IHttpClientFactory](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?WT.mc_id=AZ-MVP-5003875&view=aspnetcore-6.0)
    - [Polly for Retry, Circuit Breaker and more](https://github.com/App-vNext/Polly)

9. [CORS](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0)

10. [Options Pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)
## Things todo in pipeline
- EntityFramework for ORM
### Package Registry
- [https://docs.microsoft.com/en-us/nuget/hosting-packages/overview](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview)
### Workflow Library
- Planing to implement Elsa Workflows library (Just haven't learned it yet. So, keeping it in pipeline.)
- [https://elsa-workflows.github.io/elsa-core/](https://elsa-workflows.github.io/elsa-core/)
