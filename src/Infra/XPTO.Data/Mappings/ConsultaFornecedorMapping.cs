using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class ConsultaFornecedorMapping : IEntityTypeConfiguration<ConsultaFornecedor>
    {
        public void Configure(EntityTypeBuilder<ConsultaFornecedor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(cf => cf.Consulta)
                .WithOne();

            builder.HasOne(cf => cf.Fornecedor)
                .WithOne();

            builder.HasOne(cf => cf.Contrato)
                .WithMany(c => c.Contratados)
                .HasForeignKey(cf => cf.ContratoId);            
        }
    }
}
