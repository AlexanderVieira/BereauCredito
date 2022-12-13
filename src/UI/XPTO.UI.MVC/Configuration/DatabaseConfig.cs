using Microsoft.EntityFrameworkCore;
using XPTO.Data.Context;

namespace XPTO.UI.MVC.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddInMemoryDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("DefaultConnection"));

            return services;
        }
    }
}
