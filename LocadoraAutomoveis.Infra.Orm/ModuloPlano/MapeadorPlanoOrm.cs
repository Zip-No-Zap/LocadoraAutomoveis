using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public class MapeadorPlanoOrm : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("TBPLANO");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Grupo);

            builder.Property(x => x.LimiteQuilometragem_Controlado).HasColumnType("float").IsRequired();
            builder.Property(x => x.ValorDiario_Controlado).HasColumnType("money").IsRequired();
            builder.Property(x => x.ValorPorKm_Controlado).HasColumnType("money").IsRequired();

            builder.Property(x => x.ValorDiario_Livre).HasColumnType("money").IsRequired();

            builder.Property(x => x.ValorDiario_Diario).HasColumnType("money").IsRequired(); 
            builder.Property(x => x.ValorPorKm_Diario).HasColumnType("money").IsRequired(); 
        }
    }
}
