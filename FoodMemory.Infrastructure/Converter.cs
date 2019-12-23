using System;

namespace FoodMemory.Infrastructure
{
    public static class Converter
    {
        public static dynamic ChangeTo(dynamic source, Type dest)
        {
            return Convert.ChangeType(source, dest);
        }
    }
}
