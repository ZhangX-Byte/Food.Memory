using System;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel.Messaging
{
    public interface IEventBus
    {
        Task Publish<T>(T @event)
            where T : Event<Guid, Guid>;
    }
}
