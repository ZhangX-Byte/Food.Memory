using FoodMemory.EventEFRepository;
using FoodMemory.SharedKernel;
using FoodMemory.SharedKernel.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMemory.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddFrameWorkScope(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICommandBus), typeof(CommandBus));
            services.AddScoped(typeof(IEventBus), typeof(EventBus));
            services.AddScoped(typeof(IEventRepository<,,>), typeof(RepositoryImpl<,,>));
        }
    }
}
