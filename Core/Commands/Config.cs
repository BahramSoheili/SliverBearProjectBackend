using Core.Commands;
using Core.Configuration;
using Core.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core
{
    public static class Config
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR();

            //using TryAdd to support mocking, without that it won't be possible to override in tests

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            //services.TryAddScoped<IEventBus, EventBus>();

        }
    }
}
