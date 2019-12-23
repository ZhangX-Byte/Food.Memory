using System;

namespace FoodMemory.SharedKernel.Aggregate
{
    public abstract class Metadata: IMetadata
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public long EventVersion { get; set; }
        public Guid AggregateId { get; set; }
        public string AggregateName { get; set; }
        public long AggregateVersion { get; set; }
        public byte[] Data { get; protected set; }
        public DateTime CreatedTime { get; protected set; }
    }
}
