/* ***********************************************
 * CLR版本: 4.0.30319.42000
 * Author:ZhangXiang
 * function: 
 * history: created by Author 2018-07-26 21:45:59
 * ***********************************************/
using System;
using System.Linq;
using System.Reflection;
using FoodMemory.SharedKernel.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace FoodMemory.EventEFRepository
{
    public sealed class EventDbContext:DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<MetadataContainer> MetadataContainers { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// 模型创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
