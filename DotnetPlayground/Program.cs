using DotnetPlayground.WebApi.ExtensionMethods;
using EntityFrameworkCorePlayground.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(options => options.RegisterControllerOptions())
.AddXmlSerializerFormatters(); // To enable Consuming of Xml in endpoints

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Reading Configurations From Environment variables
config.AddEnvironmentVariables(); // To Enable Reading From Environment variables

#region Service Registrations
// We need to Add Http Client as additional service for using HttpClientFactory.
builder.Services.RegisterHttpClients(config);

// For Entity Framework Core to work
builder.Services.AddDbContext<DummyDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("MyDatabase"));
});

// Register all dependencies in an Extension method
builder.Services.RegisterDependencies();

// DI the configurations to other services
builder.Services.RegisterConfigurations(config);

// Register all custom routing constraints
builder.Services.RegisterRoutingConstraints();
#endregion

var app = builder.Build();

// Register Multiple Configuration uses by a simple middleware
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

// Register all middlewares inside an extension method
app.RegisterMiddlewares();

app.UseAuthorization();

// Register Route Endpoints by a simple middleware
app.RegisterEndpoints();
# endregion

app.Run();
