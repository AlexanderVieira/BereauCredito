using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class PlanoTarifacaoMapping : IEntityTypeConfiguration<PlanoTarifacao>
    {
        public void Configure(EntityTypeBuilder<PlanoTarifacao> builder)
        {
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.DataVigencia)
                .IsRequired()
                .HasColumnName("Data_Vigencia")
                .HasColumnType("datetime2");

            builder.Property(f => f.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("decimal(10,2)");

            builder.ToTable("Planos_Tarifacao");
        }
    }
}
