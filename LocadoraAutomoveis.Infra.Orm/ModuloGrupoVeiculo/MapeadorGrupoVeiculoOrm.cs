using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo
{
    public class MapeadorGrupoVeiculoOrm : IEntityTypeConfiguration<GrupoVeiculo>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculo> builder)
        {
            builder.ToTable("TBGRUPOVEICULO");
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Nome).HasColumnType("varchar(250)").IsRequired();

        }
    }
}
