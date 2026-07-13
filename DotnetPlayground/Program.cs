using Asp.Versioning;
using DotnetPlayground.WebApi.ExtensionMethods;
using EntityFrameworkCorePlayground.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using Scalar.AspNetCore;
using Serilog;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Initialize Serilog configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration) // Now it knows about Seq/Datadog immediately
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

Log.Information("Starting web application in {Environment}...", environment);
var config = builder.Configuration;

// Configure the full Serilog pipeline
builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(config)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());

// Register Redis as the underlying IDistributedCache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");

    // Optional: Prefix all keys in Redis so multiple apps can share the same Redis instance safely
    options.InstanceName = "MyDotNetApp_";
});

// Register HybridCache
builder.Services.AddHybridCache(options =>
{
    // You can set global defaults here
    options.MaximumPayloadBytes = 1024 * 1024; // 1MB limit
    options.MaximumKeyLength = 512;
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        // L2 (Redis) Expiration: How long the data lives in the shared distributed cache
        Expiration = TimeSpan.FromMinutes(5),

        // L1 (In-Memory) Expiration: Usually much shorter to ensure nodes don't drift too far out of sync
        LocalCacheExpiration = TimeSpan.FromMinutes(1)
    };
});

// Register Authentication in an Extension method
builder.Services.RegisterAuthentication(config);

builder.Services.AddAuthorization(options =>
{
    // Register Authorization Options in an Extension method
    options.RegisterAuthorizationOptions();
});

builder.Services.AddCors(options => options.RegisterCorsOptions(config));

// Add services to the container.
builder.Services.AddControllers(options => options.RegisterControllerOptions())
.AddXmlSerializerFormatters(); // To enable Consuming of Xml in endpoints

builder.Services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true; 
    options.DefaultApiVersion = new ApiVersion(1, 0); 
    options.ReportApiVersions = true; // Broadcasts supported/deprecated versions via 'api-supported-versions' headers
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),  // url segment: v{version}
        new HeaderApiVersionReader("x-api-version"),              // header: x-api-version
        new QueryStringApiVersionReader("api-version") // query: ?api-version=1.0
    );
}).AddApiExplorer(options => {
    options.GroupNameFormat = "'v'V"; // Formats the version group name (e.g., 'v1', 'v2')
    options.SubstituteApiVersionInUrl = true; // replace {version} in route templates
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

#region Service Registrations
// We need to Add Http Client as additional service for using HttpClientFactory.
builder.Services.RegisterHttpClients(config);

// For Entity Framework Core to work
builder.Services.AddDbContextPool<DummyDbContext>(options =>
{
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(config.GetConnectionString("MyDatabase"));
});

// Register all dependencies in an Extension method
builder.Services.RegisterDependencies();

// DI the configurations to other services
builder.Services.RegisterConfigurations(config);

// Register all custom routing constraints
builder.Services.RegisterRoutingConstraints();

builder.Services.RateLimiters();

builder.Services.AddHealthChecks();
#endregion

var app = builder.Build();

// Add Serilog request logging (adds clean, single-line HTTP request logs)
app.UseSerilogRequestLogging();

app.RegisterInlineMiddlewares();
// Register all middlewares inside an extension method
app.RegisterMiddlewares();

// Register Multiple Configuration uses by a simple middleware
app.RegisterSimpleConfigs(builder);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        // Optional: Configure default settings, like authentication schemes
        options.WithPreferredScheme("Bearer");
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// this order is important for these middlewares to work properly as expected.
app.UseAuthentication();

app.MapControllers();

app.UseRouting();

// Adds Cors support
app.UseCors();

app.UseAuthorization();

// Register Rate Limiters
app.UseRateLimiter();

// Register Route Endpoints by a simple middleware
app.RegisterEndpoints();

// Liveness Endpoint: Only checks if the API process is running (Predicate = false means no tagged checks run)
app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false
});

// Readiness Endpoint: Runs checks tagged with "ready" (e.g., the database)
app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});

app.Run();
