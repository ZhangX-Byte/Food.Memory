using System;
using FoodMemory.SharedKernel.EventDef;

namespace FoodMemory.UserDomain.Events
{
    [Serializable]
    public sealed class UserCreatedEvent : Event<Guid, Guid>
    {
        public string Name { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public UserCreatedEvent(Guid aggregateId, string name, string loginName, string password) : base(Guid.NewGuid(), aggregateId)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
        }
    }
}
