using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("varchar(100)");

            builder.OwnsOne(u => u.Senha, tf =>
            {
                tf.Property(u => u.Valor)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType($"varchar(8)");
            });

            builder.HasMany(u => u.Operacoes)
                .WithMany(o => o.Usuarios);

            builder.ToTable("Usuarios");
        }
    }
}
