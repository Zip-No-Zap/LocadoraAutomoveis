using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq;

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    public class LocadoraAutomoveisDbContext : DbContext, IContextoPersistencia
    {

        private readonly string connectionString;

        public LocadoraAutomoveisDbContext(string connectionString)
        {
            this.connectionString = connectionString;  // vem da classe ServiceLocatorManual
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        public void DesfazerAlteracoes()
        {
            var registrosAlterados = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToList();

            foreach (var registro in registrosAlterados)
            {
                switch (registro.State)
                {
                    case EntityState.Added:
                        registro.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        registro.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        registro.State = EntityState.Unchanged;
                        registro.CurrentValues.SetValues(registro.OriginalValues);
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // aqui define qual provider vai trabalhar
        {
            // var enderecoConexao = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDB;Integrated Security=True";
            // optionsBuilder.UseSqlServer(enderecoConexao); // adicionado pacote do SqlServer (entityframeworkcore.sqlserver)

            optionsBuilder.UseSqlServer(connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create(x => x.AddSerilog(Log.Logger)); // adicionado pacote serilog.extensions.logging
                                                                                                // isso vai fazer o Log ser mostrado na janela de Output /Debug 
            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        // migration

        protected override void OnModelCreating(ModelBuilder modelBuilder) // configurar modelo de banco
        {
            //modelBuilder.ApplyConfigurationsFromAssembly( typeof(LocadoraAutomoveisDbContext).Assembly );

            modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculoOrm());
            modelBuilder.ApplyConfiguration(new MapeadorClienteOrm());
            modelBuilder.ApplyConfiguration(new MapeadorCondutorOrm());
            modelBuilder.ApplyConfiguration(new MapeadorFuncionarioOrm());
            modelBuilder.ApplyConfiguration(new MapeadorPlanoOrm());
            modelBuilder.ApplyConfiguration(new MapeadorTaxaOrm());
            modelBuilder.ApplyConfiguration(new MapeadorVeiculoOrm());

            //modelBuilder.Ignore<Cliente>();   cancela a criação automática das entidades relacionadas, do tipo informado
        }
    }
}
