using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YourSneaker.Clientes.API.Models;
using YourSneaker.Core.DomainObjects;

namespace YourSneaker.Clientes.API.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMax)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMax})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            // 1 : 1 => Cliente : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Cliente);

            builder.ToTable("Clientes");
        }
    }
}
