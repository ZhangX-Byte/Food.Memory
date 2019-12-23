using System;
using System.Collections.Generic;
using System.Text;
using FoodMemory.SharedKernel.Aggregate;
using FoodMemory.UserDomain.Events;

namespace FoodMemory.UserDomain
{
    public sealed class User : AggregateRoot<Guid, Guid>
    {
        public User(Guid id, string name, string loginName, string password)
        {
            Apply(new UserCreatedEvent(id, name, loginName, password));
        }
    }
}
