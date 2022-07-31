using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVEICULO");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.GrupoPertencente);

            builder.Property(x => x.Modelo).HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Ano).HasColumnType("int").IsRequired();
            builder.Property(x => x.TipoCombustivel).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("float").IsRequired();
            builder.Property(x => x.StatusVeiculo).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.QuilometragemAtual).HasColumnType("int").IsRequired();
            builder.Property(x => x.Foto).HasColumnType("varbinary(max)").IsRequired();
        }
    }
}
