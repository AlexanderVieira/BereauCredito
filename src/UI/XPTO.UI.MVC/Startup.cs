using XPTO.UI.MVC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XPTO.UI.MVC.Data;

namespace XPTO.UI.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvcConfiguration();
            services.AddInMemoryDatabaseConfiguration(Configuration);            
            services.ResolveDependencies();            

            services.AddDbContext<XPTOUIMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("XPTOUIMVCContext")));
        }

        public void Configure(WebApplication app)
        {
            app.UseMvcConfiguration();
        }
    }
}
