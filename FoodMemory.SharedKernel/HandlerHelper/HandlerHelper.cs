using System;
using System.Collections.Generic;
using FoodMemory.SharedKernel.CommandDef;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel.HandlerHelper
{
    public sealed class HandlerHelper: IHandlerHelper
    {
        private readonly List<Type> _commandTypes;
        private readonly List<Type> _eventTypes;

        public HandlerHelper(List<Type> types, List<Type> eventTypes)
        {
            _commandTypes = types;
            _eventTypes = eventTypes;
        }

        public IEnumerable<Type> GetCommandHandlerTypes<T>() where T : Command
        {
            return _commandTypes;
        }

        public IEnumerable<Type> GetEventHandlerTypes<T, TEventIdentity, TAggregateIdentity>() where T : Event<TEventIdentity, TAggregateIdentity>
        {
            return _eventTypes;
        }
    }
}
