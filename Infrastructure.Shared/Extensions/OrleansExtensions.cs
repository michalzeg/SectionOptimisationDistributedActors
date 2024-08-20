using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers.MongoDB.Configuration;
using System.Net;
using System.Reflection;

namespace Infrastructure.Shared.Extensions
{
    public static class OrleansExtensions
    {
        private static string ServiceId => "Service";

        public static void ConfigureOrleansClient(this ConfigureHostBuilder host)
        {
            host.UseOrleansClient((context, client) =>
            {
                var mongoIp = context.Configuration["mongo"];
                var dbName = context.Configuration["dbName"];
                var isDocker = context.Configuration.GetValue<bool>("DOTNET_RUNNING_IN_CONTAINER");

                client.Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "section-optimisation-cluster";
                    options.ServiceId = ServiceId;
                })
                .Configure<ClientMessagingOptions>(options =>
                {
                    options.ResponseTimeout = TimeSpan.FromHours(1);
                });
                if (isDocker)
                {
                    client
                    .UseMongoDBClient($"mongodb://{mongoIp}")
                    .UseMongoDBClustering(x =>
                    {
                        x.DatabaseName = dbName;
                        x.Strategy = MongoDBMembershipStrategy.SingleDocument;
                    });
                }
                else
                {
                    client.UseLocalhostClustering();
                }
            });
        }

        public static void ConfigureOrleansSilo(this ConfigureHostBuilder host, string? storageName = null, Action<HostBuilderContext, ISiloBuilder>? configureDelegate = null)
        {
            host.UseOrleans((context, silo) =>
            {
                configureDelegate?.Invoke(context, silo);

                var mongoIp = context.Configuration["mongo"];
                var dbName = context.Configuration["dbName"];
                var isDocker = context.Configuration.GetValue<bool>("DOTNET_RUNNING_IN_CONTAINER");
                silo
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "section-optimisation-cluster";
                    options.ServiceId = ServiceId;
                })
                .Configure<SiloMessagingOptions>(options =>
                {
                    options.ResponseTimeout = TimeSpan.FromHours(1);
                })
                .Configure<SiloMessagingOptions>(options =>
                {
                    options.ResponseTimeout = TimeSpan.FromHours(1);
                    options.RequestProcessingWarningTime = TimeSpan.FromHours(1);
                })
                .Configure<EndpointOptions>(options =>
                {
                    if (isDocker)
                    {
                        options.GatewayListeningEndpoint = new IPEndPoint(IPAddress.Any, 30000);
                        options.SiloListeningEndpoint = new IPEndPoint(IPAddress.Any, 11111);

                        var hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                        options.AdvertisedIPAddress = hostAddresses[0];
                    }
                });
                if (isDocker)
                {
                    silo
                    .UseMongoDBClient($"mongodb://{mongoIp}")
                    .UseMongoDBClustering(x =>
                    {
                        x.DatabaseName = dbName;
                        x.Strategy = MongoDBMembershipStrategy.SingleDocument;
                    });
                }
                else
                {
                    silo.UseLocalhostClustering();
                }
                if (!string.IsNullOrWhiteSpace(storageName))
                {
                    silo.AddMongoDBGrainStorage(storageName, options =>
                    {
                        options.DatabaseName = storageName;
                    });
                }
            });
        }
    }
}
