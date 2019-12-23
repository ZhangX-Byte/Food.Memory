namespace FoodMemory.SharedKernel.EventDef
{
    public interface IEvent<out TEventIdentity>
    {
        TEventIdentity Id { get; }
    }
}
