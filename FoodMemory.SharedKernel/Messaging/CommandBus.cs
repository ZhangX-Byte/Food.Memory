using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.CommandDef;
using FoodMemory.SharedKernel.Exceptions;
using FoodMemory.SharedKernel.HandlerHelper;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMemory.SharedKernel.Messaging
{
    public sealed class CommandBus : ICommandBus
    {
        private readonly IHandlerHelper _handlerHelper;
        private readonly IServiceProvider _serviceProvider;

        public CommandBus(IHandlerHelper handlerHelper, IServiceProvider serviceProvider )
        {
            _handlerHelper = handlerHelper;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <exception cref="UnregisteredDomainCommandException"></exception>
        public async Task Send<T>(T command) where T : Command
        {
            ICommandHandler<T> handler = GetHandler<T>();
            if (handler != null)
            {
                 await handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException("no handler registered");
            }
        }

        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            List<Type> handlers = _handlerHelper.GetCommandHandlerTypes<T>().ToList();
            ICommandHandler<T> cmdHandler = handlers.Select(handler =>
                (ICommandHandler<T>)ActivatorUtilities.CreateInstance(_serviceProvider,handler)).FirstOrDefault();

            return cmdHandler;
        }
    }
}
