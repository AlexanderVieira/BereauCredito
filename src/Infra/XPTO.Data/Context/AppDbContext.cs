using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XPTO.Domain.Entities;

namespace XPTO.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<PlanoTarifacao> Planos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ValidationResult>();            

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType.BaseType == typeof(Enum))
                    {
                        var type = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                        var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                        property.SetColumnType("varchar(50)");
                        property.SetValueConverter(converter);
                    }
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
