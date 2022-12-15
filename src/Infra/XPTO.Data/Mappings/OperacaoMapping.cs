using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class OperacaoMapping : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DataOperacao)
                .IsRequired()
                .HasColumnName("Data_Operacao")
                .HasColumnType("datetime2");

            builder.Property(f => f.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(200)");

            builder.ToTable("Operacao");
        }

    }
}
