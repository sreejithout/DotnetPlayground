using DotnetPlayground.WebApi.ExtensionMethods;
using EntityFrameworkCorePlayground.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SharedPocos.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// We need to Add Http Client as additional service for using HttpClientFactory.
// Add all HttpClients in an Extension method.
builder.Services.RegisterHttpClients(builder.Configuration);

// Reading Configurations From Environment variables
builder.Configuration.AddEnvironmentVariables(); // To Enable Reading From Environment variables

Console.WriteLine($"outside: {builder.Configuration.GetValue<string>("hi")}");

// For Entity Framework Core to work
builder.Services.AddDbContext<DummyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
});

// Register all dependencies in an Extension method
builder.Services.RegisterDependencies();

// 5. DI the configurations to other services
builder.Services.RegisterConfigurations(builder.Configuration);

// Register all custom routing constraints
builder.Services.RegisterRoutingConstraints();

var app = builder.Build();

// Register Simple Configuration uses
app.RegisterSimpleConfigs(builder);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

# region Routing
app.UseRouting();

app.UseAuthorization();

// Register Route Endpoints
app.RegisterEndpoints();

# endregion

app.Run();
