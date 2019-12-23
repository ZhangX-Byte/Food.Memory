/* ***********************************************
 * CLR版本: 4.0.30319.42000
 * Author:ZhangXiang
 * function: 
 * history: created by Author 2018-07-26 20:55:09
 * ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodMemory.Infrastructure;
using FoodMemory.SharedKernel;
using FoodMemory.SharedKernel.Aggregate;
using FoodMemory.SharedKernel.EventDef;
using FoodMemory.SharedKernel.Messaging;
using Microsoft.EntityFrameworkCore;

namespace FoodMemory.EventEFRepository
{
    public sealed class
        RepositoryImpl<TEventIdentity, TAggregateIdentity, TAggregate> : IEventRepository<TEventIdentity,
            TAggregateIdentity, TAggregate> where TAggregate : class, IAggregateRoot<TEventIdentity, TAggregateIdentity>
    {
        private readonly DbContext _context;
        private readonly IEventBus _eventBus;

        /// <summary>
        /// 仓储构造器
        /// </summary>
        /// <param name="context"></param>
        /// <param name="eventBus"></param>
        public RepositoryImpl(EventDbContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        public async Task<List<Event<TEventIdentity, TAggregateIdentity>>> GetEvents(
            Expression<Func<Event<TEventIdentity, TAggregateIdentity>, bool>> expression)
        {
            return await _context.Set<Event<TEventIdentity, TAggregateIdentity>>().Where(expression).ToListAsync();
        }

        public async Task Save(AggregateRoot<TEventIdentity, TAggregateIdentity> aggregate)
        {
            List<Event<TEventIdentity, TAggregateIdentity>> uncommittedChanges = aggregate.GetUncommittedEvent();
            long version = aggregate.Version;

            foreach (Event<TEventIdentity, TAggregateIdentity> @event in uncommittedChanges)
            {
                version++;
                //if (version > 2)
                //{
                //    if (version % 3 == 0)
                //    {
                //        var originator = (IOriginator)aggregate;
                //        var memento = originator.GetMemento();
                //        memento.Version = version;
                //        SaveMemento(memento);
                //    }
                //}
                @event.Version = version;

                var metadataContainer = new MetadataContainer
                {
                    AggregateId = Converter.ChangeTo(@event.AggregateId, typeof(Guid)),
                    AggregateName = aggregate.GetType().FullName,
                    AggregateVersion = version,
                    EventId = Converter.ChangeTo(@event.Id, typeof(Guid)),
                    EventName = @event.GetType().FullName,
                    EventVersion = version
                };
                metadataContainer.Serializable(@event);

                // var ss = metadataContainer.Deserialize<dynamic>();

                _context.Set<MetadataContainer>().Add(metadataContainer);
            }

            await _context.SaveChangesAsync();

            foreach (Event<TEventIdentity, TAggregateIdentity> @event in uncommittedChanges)
            {
                dynamic desEvent = Converter.ChangeTo(@event, @event.GetType());
                //_eventBus.Publish(desEvent);
            }
        }
    }
}
