using System;

namespace FoodMemory.SharedKernel.Aggregate
{
    /// <summary>
    /// 元数据
    /// </summary>
    public interface IMetadata
    {
        /// <summary>
        /// 事件Id
        /// </summary>
        Guid EventId { get; set; }

        /// <summary>
        /// 事件名称
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// 事件版本
        /// </summary>
        long EventVersion { get; set; }

        /// <summary>
        /// 聚合Id
        /// </summary>
        Guid AggregateId { get; set; }

        /// <summary>
        /// 聚合名称
        /// </summary>
        string AggregateName { get; set; }

        /// <summary>
        /// 聚合版本
        /// </summary>
        long AggregateVersion { get; set; }

        /// <summary>
        /// 元数据
        /// </summary>
        byte[] Data { get;}
        
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreatedTime { get; }
    }
}
