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
            builder.Property(x => x.CondutorLocacao).HasColumnType("varchar(120)").IsRequired();
            builder.Property(x => x.VeiculoLocacao).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.PlanoLocacao).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ItensTaxa);
            builder.Property(x => x.DataLocacao).HasColumnType("float").IsRequired();
            builder.Property(x => x.DataDevolucao).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
