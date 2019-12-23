using System;
using System.Collections.Generic;
using System.Linq;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel.Aggregate
{
    public abstract class
        AggregateRoot<TEventIdentity, TAggregateIdentity> : IAggregateRoot<TEventIdentity, TAggregateIdentity>
    {
        private readonly List<Event<TEventIdentity, TAggregateIdentity>> _uncommmittedEvents;

        public long Version { get; set; }

        protected AggregateRoot()
        {
            _uncommmittedEvents = new List<Event<TEventIdentity, TAggregateIdentity>>();
        }

        public List<Event<TEventIdentity, TAggregateIdentity>> GetUncommittedEvent()
        {
            return _uncommmittedEvents;
        }

        protected void Apply(Event<TEventIdentity, TAggregateIdentity> @event)
        {
            _uncommmittedEvents.Add(@event);
        }

        protected void LoadsFromHistory(List<Event<TEventIdentity, TAggregateIdentity>> historyEvent)
        {
            foreach (var e in historyEvent)
            {
                dynamic d = this;
                d.Handle(Convert.ChangeType(e, e.GetType()));
            }

            Version = historyEvent.Last().Version;
        }
    }
}
