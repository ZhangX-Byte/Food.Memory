using System;

namespace FoodMemory.SharedKernel.Exceptions
{
    public sealed class UnregisteredDomainCommandException:Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message) { }
    }
}
