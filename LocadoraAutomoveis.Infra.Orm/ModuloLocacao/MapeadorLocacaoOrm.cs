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
            builder.HasOne(x => x.Grupo);
            builder.HasOne(x => x.PlanoLocacao);
            builder.HasMany(x => x.ItensTaxa);
            builder.Property(x => x.DataLocacao).HasColumnType("date");
            builder.Property(x => x.DataDevolucao).HasColumnType("date");
            builder.Property(x => x.DataDevolvidoDeFato).HasColumnType("date");
            builder.Property(x => x.PlanoLocacao_Descricao).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.TotalPrevisto).HasColumnType("money");
            builder.Property(x => x.Status).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.NivelTanqueVeiculo).HasColumnType("varchar(10)");
        }
    }
}
