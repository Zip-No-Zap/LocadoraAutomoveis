using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCONDUTOR");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Cnh).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.VencimentoCnh).HasColumnType("date").IsRequired();

            builder.HasOne(x => x.Cliente);



        }
    }
}
