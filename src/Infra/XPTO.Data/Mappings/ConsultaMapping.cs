using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPTO.Domain.Entities;

namespace XPTO.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.ContratoId)
                .HasColumnName("Contrato");

            builder.Property(u => u.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("varchar(50)");

            builder.OwnsOne(u => u.Senha, tf =>
            {
                tf.Property(u => u.Valor)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType($"varchar(8)");
            });

            builder.HasOne(c => c.PlanoTarifacao)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PlanoTarifacaoId);

            builder.HasOne(c => c.Fornecedor)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.FornecedorId);            

            builder.ToTable("Consulta");
        }
    }
}
