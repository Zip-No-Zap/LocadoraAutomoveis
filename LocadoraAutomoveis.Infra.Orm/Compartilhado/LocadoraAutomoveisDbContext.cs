using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;


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
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(LocadoraAutomoveisDbContext).Assembly );

            //modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculoOrm());

            //modelBuilder.Ignore<Cliente>();  // cancela a criação automática das entidades relacionadas, do tipo informado
            //modelBuilder.Ignore<Condutor>();
            //modelBuilder.Ignore<Funcionario>();
            //modelBuilder.Ignore<Taxa>();
            //modelBuilder.Ignore<GrupoVeiculo>();
            //modelBuilder.Ignore<Veiculo>();
        }
    }
}
