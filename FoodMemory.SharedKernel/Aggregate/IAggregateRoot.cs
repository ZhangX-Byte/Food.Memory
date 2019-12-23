using System.Collections.Generic;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel.Aggregate
{
    public interface IAggregateRoot<TEventIdentity, TAggregateIdentity>
    {
        List<Event<TEventIdentity, TAggregateIdentity>> GetUncommittedEvent();
    }
}
