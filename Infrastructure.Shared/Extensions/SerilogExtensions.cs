using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Core;
using System.Reflection;

namespace Infrastructure.Shared.Extensions
{
    public static class SerilogExtensions
    {
        public const string LogCollectionName = "logs";
        public const string LogDatabaseName = "logs";
        public static void ConfigureSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog((context, configuration) =>
            {
                var name = Assembly.GetEntryAssembly()?.FullName;
                var mongoIp = context.Configuration["mongo"];
                configuration.Enrich.WithProperty("Application", name);
                configuration.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning);
                configuration.WriteTo.Console();
                configuration.WriteTo.MongoDBBson(cfg =>
                {
                    cfg.SetCollectionName(LogCollectionName);

                    cfg.SetCreateCappedCollection();
                    cfg.SetMongoUrl($"mongodb://{mongoIp}/{LogDatabaseName}");
                });
            });
        }
    }
}
