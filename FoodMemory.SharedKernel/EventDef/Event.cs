using System;

namespace FoodMemory.SharedKernel.EventDef
{
    [Serializable]
    public abstract class Event<TEventIdentity, TAggregateIdentity> : IEvent<TEventIdentity>
    {
        public TEventIdentity Id { get; }

        public TAggregateIdentity AggregateId { get; }

        public long Version { get; set; }

        protected Event(TEventIdentity eventId, TAggregateIdentity aggregateId)
        {
            Id = eventId;
            AggregateId = aggregateId;
        }
    }
}
