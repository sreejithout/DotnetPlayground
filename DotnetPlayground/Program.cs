using Asp.Versioning;
using DotnetPlayground.WebApi.ExtensionMethods;
using EntityFrameworkCorePlayground.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Reading Configurations From Environment variables
config.AddEnvironmentVariables(); // To Enable Reading From Environment variables

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
#endregion

var app = builder.Build();

// Map OpenAPI endpoints with Document-Per-Version isolation
app.MapOpenApi(); // Auto-splits v1, v2 docs cleanly

app.RegisterInlineMiddlewares();
// Register all middlewares inside an extension method
app.RegisterMiddlewares();

// Register Multiple Configuration uses by a simple middleware
app.RegisterSimpleConfigs(builder);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.Run();
