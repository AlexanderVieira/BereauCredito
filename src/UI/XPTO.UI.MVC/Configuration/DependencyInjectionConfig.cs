using XPTO.Core;
using XPTO.Core.Data;
using XPTO.Crosscutting.Bereaus;
using XPTO.Crosscutting.Bereaus.Interfaces;
using XPTO.Data.Context;
using XPTO.Data.Repositories;
using XPTO.Domain.Interfaces.Repositories;
using XPTO.Domain.Interfaces.Services;
using XPTO.Service;

namespace XPTO.UI.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Data
            services.AddScoped<AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
            #endregion

            #region Services
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IOperacaoService, OperacaoService>();
            services.AddScoped<IConsultaService, SpcService>();
            services.AddScoped<IConsultaService, SerasaService>();
            services.AddScoped<IConsultaService, ReceitaFederalService>();
            #endregion

            #region CrossCutting
            services.AddScoped<ISpcFacade, SpcFacade>();
            services.AddScoped<ISerasaFacade, SerasaFacade>();
            services.AddScoped<IReceitaFederalFacade, ReceitaFederalFacade>();
            #endregion

            return services;
        }
    }
}
