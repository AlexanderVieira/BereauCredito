using Microsoft.EntityFrameworkCore;
using XPTO.Data.Context;

namespace XPTO.UI.MVC.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddInMemoryDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                     providerOptions => providerOptions.EnableRetryOnFailure()));

            return services;
        }
    }
}
