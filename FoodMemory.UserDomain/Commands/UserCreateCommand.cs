using System;
using FoodMemory.SharedKernel.CommandDef;

namespace FoodMemory.UserDomain.Commands
{
    public sealed class UserCreateCommand : Command
    {
        private static readonly long CreateCommandVersion = 0;

        public string Name { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
       
        public UserCreateCommand(Guid aggregateId,string name,string loginName,string password) : base(aggregateId, CreateCommandVersion)
        {
            Name = name;
            LoginName = loginName;
            Password = password;
        }
    }
}
