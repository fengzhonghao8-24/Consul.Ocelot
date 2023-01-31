using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddConsul();

builder.Services.AddLogging(builder =>
{
    builder.AddFilter("Ocelot", LogLevel.Warning);
    builder.AddLog4Net();
});

var app = builder.Build();

app.UseOcelot();

app.Run();
