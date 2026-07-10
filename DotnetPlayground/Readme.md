# Dotnet Playground
## .NET 10 api solution to learn the fundamentals step by step

01. [Based on .NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
02. Layering (Trying a Clean Architecture here)
    - Business Logic Layer **DotnetPlayground.BLL**
        - Interfaces (even the one's for Repositories)
        - Models
        - DTOs
        - Enums
    - Data Access Layer **DotnetPlayground.DAL**
    - as per dependency inversion or clean architecture level, we are going to move the interfaces for the the repositories to BLL layer. Means, we will be referencing BLL from DAL and not other way around.
03. Dependency Injection
    - [built-in DI provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-10.0)
04. [Configurations](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-10.0)
    - [Options Pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-10.0)
    - [IOptionsSnapshot](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1?view=dotnet-plat-ext-7.0)
    - [IOptionsMonitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1?view=dotnet-plat-ext-7.0)
05. [Routing](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-10.0)
06. [Model Binding](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-10.0)
07. Http Client 
    - [IHttpClientFactory](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0)
08. [CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-10.0)
09. [EF Core](https://docs.microsoft.com/en-us/ef/core/)

## Things todo in pipeline
- [Security Headers (HSTS)](https://learn.microsoft.com/en-us/aspnet/core/security/http-headers?view=aspnetcore-10.0)
- [Enforcing HTTPs](https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-10.0)
- [API Versioning](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/api-versioning?view=aspnetcore-10.0)
- [Rate Limiting](https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-10.0)
- [Cancellation Token](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads?view=net-8.0)
- [Health Checks](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0)
- [OpenTelemetry, Distributed Tracking](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/distributed-tracing?view=dotnet-10)
- [Structured Logging with Serilog](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-10.0#structured-logging)
- [Open API Documentation with Scalar instead of Swagger](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/openapi?view=aspnetcore-10.0)
- [Caching](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/?view=aspnetcore-10.0)
- [Idempotency](https://docs.microsoft.com/en-us/aspnet/core/web-api/idempotency?view=aspnetcore-10.0)
- [Standardized API Response](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/standardized-api-response?view=aspnetcore-10.0)
- [Standardized Error Response](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/standardized-error-response?view=aspnetcore-10.0)
- DTOs
- [Resiliency (Retry, Circuit Breaker, Fallback, Timeout)](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency)
  - [Retry](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implementing-retry)
  - [Circuit Breaker](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency)
  - [Fallback](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency#fallback)
  - [Timeout](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/resiliency#timeout)
- [Polly for Retry, Circuit Breaker and more](https://github.com/App-vNext/Polly)
      - Resilient(https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0#resilient-http-requests)
- 
- Azure Logic Apps for workflow orchestration. [https://learn.microsoft.com/en-us/azure/logic-apps/](https://learn.microsoft.com/en-us/azure/logic-apps/)
- Package Registry
  - [https://docs.microsoft.com/en-us/nuget/hosting-packages/overview](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview)

 CI/CD