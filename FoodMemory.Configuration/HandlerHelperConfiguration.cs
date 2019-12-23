using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FoodMemory.SharedKernel;
using FoodMemory.SharedKernel.HandlerHelper;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMemory.Configuration
{
    public static class HandlerHelperConfiguration
    {
        private static readonly object Locker = new object();

        public static void AddHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            var commandHandlerTypes = new List<Type>();
            var eventHandlerTypes = new List<Type>();
            Parallel.ForEach(assemblies, assembly =>
            {
                lock (Locker)
                {
                    commandHandlerTypes.AddRange(GetCommandHandlerTypes(assembly));
                    eventHandlerTypes.AddRange(GetEventHandlerTypes(assembly));
                }
            });

            IHandlerHelper handlerHelper = new HandlerHelper(commandHandlerTypes, eventHandlerTypes);
            services.AddSingleton(handlerHelper);
        }

        private static IEnumerable<Type> GetCommandHandlerTypes(Assembly assembly)
        {
            IEnumerable<Type> handlers = assembly.GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>)));
            return handlers;
        }

        private static IEnumerable<Type> GetEventHandlerTypes(Assembly assembly)
        {
            IEnumerable<Type> handlers = assembly.GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)));
            return handlers;
        }
    }
}
