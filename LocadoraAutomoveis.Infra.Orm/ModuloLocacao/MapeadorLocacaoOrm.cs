using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLOCACAO");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.CondutorLocacao);
            builder.HasOne(x => x.ClienteLocacao);
            builder.HasOne(x => x.VeiculoLocacao);
            builder.HasOne(x => x.PlanoLocacao);
            builder.HasMany(x => x.ItensTaxa);
            builder.Property(x => x.DataLocacao).HasColumnType("date").IsRequired();
            builder.Property(x => x.DataDevolucao).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
