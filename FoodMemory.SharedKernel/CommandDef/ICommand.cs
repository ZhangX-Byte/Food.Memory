namespace FoodMemory.SharedKernel.CommandDef
{
    public interface ICommand<out T>
    {
        T Id { get; }
    }
}
