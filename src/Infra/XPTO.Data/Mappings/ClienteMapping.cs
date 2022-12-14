using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Core.DomainObjects.ValueObjects;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.OwnsOne(c => c.Nome, tf => 
            { 
                tf.Property(c => c.NomeCompleto)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)"); 
            });

            builder.OwnsOne(c => c.Cnpj, tf => 
            { 
                tf.Property(c => c.Numero)
                .IsRequired()
                .HasColumnName("Cnpj")
                .HasColumnType($"varchar({Cnpj.CNPJ_MAX_LENGTH})"); 
            });

            builder.HasMany(c => c.Telefones)
                .WithOne()
                .HasForeignKey(t => t.ClienteId);

            builder.HasMany(c => c.Usuarios)
                .WithOne()
                .HasForeignKey(u => u.ClienteId);

            builder.HasMany(c => c.Consultas)
                .WithMany(c => c.Clientes);

            builder.ToTable("Clientes");
        }
    }
}
