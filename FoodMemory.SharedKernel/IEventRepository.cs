/* ***********************************************
 * CLR版本: 4.0.30319.42000
 * Author:ZhangXiang
 * function: 定义接口
 * history: created by Author 2018-07-26 20:44:59
 * ***********************************************/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.Aggregate;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.SharedKernel
{
    public interface IEventRepository<TEventIdentity, TAggregateIdentity,TAggregate>
    {
        Task<List<Event<TEventIdentity, TAggregateIdentity>>> GetEvents(Expression<Func<Event<TEventIdentity, TAggregateIdentity>, bool>> expression);

        Task Save(AggregateRoot<TEventIdentity, TAggregateIdentity> aggregate);
     
    }
}
