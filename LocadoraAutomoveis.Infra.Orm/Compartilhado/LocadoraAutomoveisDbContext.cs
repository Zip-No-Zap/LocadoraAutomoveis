using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    public class LocadoraAutomoveisDbContext : DbContext, IContextoPersistencia
    {
        public DbSet<Condutor> Condutores { get; set; } // lista da entidade deste context

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // aqui define qual provider vai trabalhar
        {
            var enderecoConexao = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDB;Integrated Security=True";

            optionsBuilder.UseSqlServer(enderecoConexao); // adicionado pacote do SqlServer (entityframeworkcore.sqlserver)

            ILoggerFactory loggerFactory = LoggerFactory.Create(x => x.AddSerilog(Log.Logger)); // adicionado pacote serilog.extensions.logging
                                                                                                // isso vai fazer o Log ser mostrado na janela de Output /Debug 
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }


        // migration

        protected override void OnModelCreating(ModelBuilder modelBuilder) // configurar modelo de banco
        {
            modelBuilder.ApplyConfiguration(new MapeadoPlanoOrm());

            modelBuilder.Ignore<Cliente>();  // cancela a criação automática das entidades relacionadas, do tipo informado
            modelBuilder.Ignore<Funcionario>();
            modelBuilder.Ignore<Plano>();
            modelBuilder.Ignore<Taxa>();
            modelBuilder.Ignore<GrupoVeiculo>();
            modelBuilder.Ignore<Veiculo>();
        }
    }
}
