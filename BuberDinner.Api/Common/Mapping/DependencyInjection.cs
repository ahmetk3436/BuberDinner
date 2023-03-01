using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection service)
        {
            var config =    TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            service.AddSingleton(config);
            service.AddScoped<IMapper, ServiceMapper>();  
            return service;
        }
    }
}