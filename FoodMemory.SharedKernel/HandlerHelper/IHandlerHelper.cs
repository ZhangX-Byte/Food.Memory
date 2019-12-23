using System;
using System.Collections.Generic;
using FoodMemory.SharedKernel.CommandDef;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel.HandlerHelper
{
    /// <summary>
    /// 程序集帮助接口
    /// </summary>
    public interface IHandlerHelper
    {
        /// <summary>
        /// 获取命令处理类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<Type> GetCommandHandlerTypes<T>() where T : Command;

        /// <summary>
        /// 获取事件处理类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TEventIdentity"></typeparam>
        /// <typeparam name="TAggregateIdentity"></typeparam>
        /// <returns></returns>
        IEnumerable<Type> GetEventHandlerTypes<T, TEventIdentity, TAggregateIdentity>()
            where T : Event<TEventIdentity, TAggregateIdentity>;
    }
}
