using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class ContratoMapping : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(pt => pt.DataVigencia)
                .IsRequired()
                .HasColumnName("Data_Vigencia")
                .HasColumnType("datetime2");

            builder.Property(f => f.Valor)
                .IsRequired()
                .HasColumnName("Valor")
                .HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.Consulta)
                .WithOne(c => c.Contrato)
                .HasForeignKey<Consulta>(c => c.ContratoId);

            builder.ToTable("Contrato");
        }

    }
}
