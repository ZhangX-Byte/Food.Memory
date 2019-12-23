using System.Threading.Tasks;
using FoodMemory.SharedKernel.CommandDef;

namespace FoodMemory.SharedKernel.Messaging
{
    public interface ICommandBus
    {
        Task Send<T>(T command) where T : Command;
    }
}
