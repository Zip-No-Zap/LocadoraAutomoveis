using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxa
{
    public class MapeadoTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTAXA");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Tipo).HasColumnType("vatchat(20)").IsRequired(); 
            builder.Property(x => x.Descricao).HasColumnType("vatchat(100)").IsRequired(); 
            builder.Property(x => x.Valor).HasColumnType("float").IsRequired(); 
        }
    }
}
