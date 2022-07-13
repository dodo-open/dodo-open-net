using DoDo.Open.Client;
using DoDo.Open.Sdk.Options;
using DoDo.Open.Sdk.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureAppConfiguration((context, configurationBuilder) =>
{
    configurationBuilder.AddJsonFile("appsettings.json", optional: false);
    if (context.HostingEnvironment.IsDevelopment())
    {
        configurationBuilder.AddJsonFile("appsettings.Development.json", optional: true);
    }
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddHostedService<HostedService>();

    services.Configure<OpenApiOptions>(hostContext.Configuration.GetSection("DoDo:Api"));
    services.Configure<OpenEventOptions>(hostContext.Configuration.GetSection("DoDo:Event"));

    services.AddSingleton<IOpenApiService, OpenApiService>();
    services.AddSingleton<IOpenEventService, OpenEventService>();

    services.AddSingleton<IEventProcessService, EventProcessor>();
});


var app = builder.Build();

await app.StartAsync();
