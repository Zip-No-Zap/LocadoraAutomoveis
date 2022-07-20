using Autofac;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Cliente;
using LocadoraAutomoveis.WinFormsApp.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        IContainer container;
        ContainerBuilder builder;

        public ServiceLocatorComAutofac()
        {
            builder = new();

            CriarBuilderCliente(builder);
            CriarBuilderCondutor(builder);
            CriarBuilderFuncionario(builder);
            CriarBuilderGrupoVeiculo(builder);
            CriarBuilderPlano(builder);
            CriarBuilderTaxa(builder);
            CriarBuilderVeiculo(builder);

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
