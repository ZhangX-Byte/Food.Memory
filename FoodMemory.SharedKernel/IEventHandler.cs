using System;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel
{
    public interface IEventHandler<in TEvent> where TEvent : Event<Guid,Guid>
    {
        Task Handle(TEvent handle);
    }
}
