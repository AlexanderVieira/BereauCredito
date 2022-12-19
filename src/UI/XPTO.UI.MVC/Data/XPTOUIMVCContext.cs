using Microsoft.EntityFrameworkCore;
using XPTO.UI.MVC.Models;

namespace XPTO.UI.MVC.Data
{
    public class XPTOUIMVCContext : DbContext
    {
        public XPTOUIMVCContext (DbContextOptions<XPTOUIMVCContext> options)
            : base(options)
        {
        }

        public DbSet<FornecedorViewModel> FornecedorResponseViewModel { get; set; } = default!;

        public DbSet<UsuarioViewModel> UsuarioResponseViewModel { get; set; }

        public DbSet<OperacaoViewModel> OperacaoResponseViewModel { get; set; }

        public DbSet<ConsultaViewModel> ConsultaResponseViewModel { get; set; }

        public DbSet<PlanoTarifacaoViewModel> PlanoTarifacaoResponseViewModel { get; set; }
    }
}
