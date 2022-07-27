using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    internal class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCLIENTE");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoCliente).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(20)");
            builder.Property(x => x.Cnpj).HasColumnType("varchar(20)");

        }
    }
}
