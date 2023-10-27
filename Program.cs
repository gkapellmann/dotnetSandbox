
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using System.Reflection;

using Veronica.Sandbox.WS;
using Veronica.Sandbox.WS.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {

        LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);
        //services.AddTransient<ITransientClass, TransientClass>();

        //services.AddScoped<IScopedClass, ScopedClass>();

        services.AddSingleton<ISingletonClass, SingletonClass>();

        services.AddHostedService<Worker>();
        //services.AddHostedService<WorkerTwo>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

    })
    .ConfigureLogging((context, logging) => {
        // See: https://github.com/dotnet/runtime/issues/47303
        logging.AddConfiguration(
            context.Configuration.GetSection("Logging"));
    })
    .Build();

await host.RunAsync();