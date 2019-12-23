using System.Threading.Tasks;
using FoodMemory.DataTransferObjects;
using FoodMemory.SharedKernel;
using FoodMemory.UserDomain.Events;

namespace FoodMemory.UserDomain.EventHandlers
{
    public sealed class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent handle)
        {
            var userDto = new UserDto
            {
                ID = handle.AggregateId,
                LoginName = handle.LoginName,
                Name = handle.Name,
                Password = handle.Password,
                Version = handle.Version
            };
        }
    }
}