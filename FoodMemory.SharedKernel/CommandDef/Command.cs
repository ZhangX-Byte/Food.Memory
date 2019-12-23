using System;

namespace FoodMemory.SharedKernel.CommandDef
{
    public abstract class Command : ICommand<Guid>
    {
        public Guid Id { get; }

        public long Version { get; }

        protected Command(Guid aggregateId,long version)
        {
            Id = aggregateId;
            Version = version;
        }
    }
}
