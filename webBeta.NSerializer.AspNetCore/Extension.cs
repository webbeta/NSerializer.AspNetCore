using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace webBeta.NSerializer.AspNetCore
{
    public static class Extension
    {
        public static void AddNSerializer(this IServiceCollection services)
        {
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var serializer = NSerializerBuilder.Build()
                .WithCache(new MemoryCache((IMemoryCache) serviceProvider.GetService(typeof(IMemoryCache))))
                .WithEnvironment(
                    new Environment((IHostEnvironment) serviceProvider.GetService(typeof(IHostEnvironment))))
                .WithConfigurationProvider(
                    new ConfigurationProvider((IConfiguration) serviceProvider.GetService(typeof(IConfiguration))))
                .Get();
            services.AddSingleton(serializer);
        }
    }
}