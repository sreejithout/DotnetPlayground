using DotnetPlayground;
using EntityFrameworkCorePlayground.Data;
using Microsoft.EntityFrameworkCore;
using SharedPocos.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// We need to Add Http Client as additional service for using HttpClientFactory.
builder.Services.AddHttpClient();

// Reading Configurations
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // 1. from appSettings
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true); // 1. from appSettings.Development, QA, Stage, Production etc..
builder.Configuration.AddEnvironmentVariables(); // 3. From Environment variables
Console.WriteLine($"outside: {builder.Configuration.GetValue<string>("hi")}");


builder.Services.AddDbContext<DummyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabase"));
});

builder.Services.AllDependencies();

// 5. DI the configurations to other services
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("appOptions"));
builder.Services.Configure<PokemonApiOptions>(builder.Configuration.GetSection(PokemonApiOptions.PokemonApi));

var app = builder.Build();

// CONFIGURATIONS: Creating a simple custom middleware to read from configurations
app.Use(async (context, next) =>
{
    // 1. take directly from configuration
    Console.WriteLine($"inside: {builder.Configuration.GetValue<string>("hi")}");
    
    // 2. take directly from configuration, from a key inside a section
    Console.WriteLine($"inside angular version: {builder.Configuration.GetValue<string>("appOptions:angularFeatures:version")}");

    // 3. Bind to a model
    var appOptions1 = new AppOptions();
    builder.Configuration.GetSection("appOptions").Bind(appOptions1);
    Console.WriteLine($"inside .NET version: {appOptions1.CSharpFeatures.Version}");

    // 4. Bind to model: different approach
    var appOptions = builder.Configuration.GetSection("appOptions").Get<AppOptions>();
    Console.WriteLine($"inside .NET version: {appOptions.DotnetFeatures.Version}");

    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
