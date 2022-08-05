using Autofac;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.Infra.Logs;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Cliente;
using LocadoraAutomoveis.WinFormsApp.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo;
using LocadoraAutomoveis.WinFormsApp.ModuloLocacao;
using LocadoraVeiculos.Infra.BancoDados;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        IContainer container;
        ContainerBuilder builder;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

            var configuracao = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("ConfiguracaoAplicacao.json")
                          .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");


            builder.RegisterType<LocadoraAutomoveisDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioClienteOrm>();
            builder.RegisterType<ServicoCliente>();
            builder.RegisterType<ControladorCliente>();

            builder.RegisterType<RepositorioGrupoVeiculoOrm>().As<IRepositorioGrupoVeiculoOrm>();
            builder.RegisterType<ServicoGrupoVeiculo>();
            builder.RegisterType<ControladorGrupoVeiculo>();

            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionarioOrm>();
            builder.RegisterType<ServicoFuncionario>();
            builder.RegisterType<ControladorFuncionario>();

            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutorOrm>();
            builder.RegisterType<ServicoCondutor>();
            builder.RegisterType<ControladorCondutor>();

            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxaOrm>();
            builder.RegisterType<ServicoTaxa>();
            builder.RegisterType<ControladorTaxa>();

            builder.RegisterType<RepositorioVeiculoOrm>().As<IRepositorioVeiculoOrm>();
            builder.RegisterType<ServicoVeiculo>();
            builder.RegisterType<ControladorVeiculo>();

            builder.RegisterType<RepositorioPlanoOrm>().As<IRepositorioPlanoOrm>();
            builder.RegisterType<ServicoPlano>();
            builder.RegisterType<ControladorPlano>();

            builder.RegisterType<RepositorioLocacaoOrm>().As<IRepositorioLocacaoOrm>();
            builder.RegisterType<ServicoLocacao>();
            builder.RegisterType<ControladorLocacao>();

            builder.RegisterType<ControladorConfiguracao>();
            builder.RegisterType<ConfiguracaoLogger>();
            builder.RegisterType<ConfiguracaoControl>();

            //CriarBuilderCliente(builder);
            //CriarBuilderCondutor(builder);
            //CriarBuilderFuncionario(builder);
            //CriarBuilderGrupoVeiculo(builder);
            //CriarBuilderPlano(builder);
            //CriarBuilderTaxa(builder);
            //CriarBuilderVeiculo(builder);

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
           return container.Resolve<T>();
        }

        #region builders

        private void CriarBuilderCliente(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();
        }

        private void CriarBuilderCondutor(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();
        }

        private void CriarBuilderFuncionario(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();
        }

        private void CriarBuilderGrupoVeiculo(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoGrupoVeiculo>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculo>().AsSelf();
        }

        private void CriarBuilderPlano(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoPlano>().AsSelf();
            builder.RegisterType<ControladorPlano>().AsSelf();
        }

        private void CriarBuilderTaxa(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();
        }

        private void CriarBuilderVeiculo(ContainerBuilder builder)
        {
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();
        }

        #endregion
    }
}
