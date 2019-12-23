using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.EventDef;
using FoodMemory.SharedKernel.HandlerHelper;

namespace FoodMemory.SharedKernel.Messaging
{
    public sealed class EventBus:IEventBus
    {
        private readonly IHandlerHelper _handlerHelper;

        public EventBus(IHandlerHelper handlerHelper)
        {
            _handlerHelper = handlerHelper;
        }

        public async Task Publish<T>(T @event) where T : Event<Guid, Guid>
        {
            IEnumerable<IEventHandler<T>> handlers =GetHandlers<T>();
            foreach (IEventHandler<T> eventHandler in handlers)
            {
                await eventHandler.Handle(@event);
            }
        }

        private IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event<Guid, Guid>
        {
            List<Type> handlers = _handlerHelper.GetEventHandlerTypes<T, Guid, Guid>().ToList();
            IEnumerable<IEventHandler<T>> eventHandlers = handlers.Select(handler =>
                (IEventHandler<T>)Activator.CreateInstance(handler));
            return eventHandlers;
        }
      
    }
}
