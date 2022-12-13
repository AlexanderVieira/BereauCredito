using XPTO.Data.Context;

namespace XPTO.UI.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            return services;
        }
    }
}
