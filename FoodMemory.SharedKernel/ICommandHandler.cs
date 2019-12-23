using System;
using System.Threading.Tasks;
using FoodMemory.SharedKernel.CommandDef;

namespace FoodMemory.SharedKernel
{
    public interface ICommandHandler<in TCommand> where TCommand:ICommand<Guid>
    {
        Task Execute(TCommand command);
    }
}
