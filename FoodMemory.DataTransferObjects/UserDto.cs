using System;

namespace FoodMemory.DataTransferObjects
{
    /// <summary>
    /// 用户传输模型
    /// </summary>
    public sealed class UserDto
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public long Version { get; set; }
    }
}
