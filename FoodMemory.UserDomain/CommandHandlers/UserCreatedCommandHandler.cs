using System;
using System.Threading.Tasks;
using FoodMemory.SharedKernel;
using FoodMemory.UserDomain.Commands;

namespace FoodMemory.UserDomain.CommandHandlers
{
    public sealed class UserCreatedCommandHandler : ICommandHandler<UserCreateCommand>
    {
        private readonly IEventRepository<Guid, Guid, User> _eventRepository;

        public UserCreatedCommandHandler(IEventRepository<Guid, Guid, User> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Execute(UserCreateCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), "command");
            }
            if (_eventRepository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var aggregate =
                new User(command.Id, command.Name, command.LoginName, command.Password) { Version = command.Version };
            await _eventRepository.Save(aggregate);
        }
    }
}
