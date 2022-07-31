using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LocadoraAutomoveis.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFUNCIONARIO");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(120)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Estado).HasColumnType("varchar(2)").IsRequired();
            builder.Property(x => x.Perfil).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Salario).HasColumnType("money").IsRequired();
            builder.Property(x => x.DataAdmissao).HasColumnType("date").IsRequired(); 
            builder.Property(x => x.Login).HasColumnType("varchar(50)").IsRequired(); 
            builder.Property(x => x.Senha).HasColumnType("varchar(50)").IsRequired(); 
        }
    }
}
