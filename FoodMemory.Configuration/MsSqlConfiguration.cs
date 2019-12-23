using FoodMemory.EventEFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMemory.Configuration
{
    public static class MsSqlConfiguration
    {
        public static void UserSqlServer(this IServiceCollection services,IConfiguration configuration,string connectionStringName)
        {
            services.AddDbContextPool<EventDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(connectionStringName)));
        }
    }
}
