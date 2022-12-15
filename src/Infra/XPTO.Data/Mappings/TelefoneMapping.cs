using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnName("Numero")
                .HasColumnType("varchar(13)");

            builder.ToTable("Telefone");
        }
    }
}
