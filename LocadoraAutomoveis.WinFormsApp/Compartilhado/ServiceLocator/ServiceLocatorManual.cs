using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Cliente;
using LocadoraAutomoveis.WinFormsApp.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using System.Collections.Generic;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            return (T)controladores[typeof(T).GetType().Name];
        }

        private void InicializarControladores()
        {
            controladores = new Dictionary<string, ControladorBase>();

            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioGrupoVeiculo = new RepositorioGrupoVeiculoEmBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var repositorioVeículo = new RepositorioVeiculoEmBancoDados();
            //var repositorioPlano = new RepositorioPlanoEmBancoDados();

            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoGrupoVeiculo = new ServicoGrupoVeiculo(repositorioGrupoVeiculo);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeículo);
            //var servicoPlano = new ServicoPlano(repositorioPlano);

            controladores.Add("Funcionário", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("Cliente", new ControladorCliente(servicoCliente));
            controladores.Add("Grupo de Veículo", new ControladorGrupoVeiculo(servicoGrupoVeiculo));
            controladores.Add("Taxa", new ControladorTaxa(servicoTaxa));
            controladores.Add("Condutor", new ControladorCondutor(servicoCondutor, servicoCliente));
            controladores.Add("Veículo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));
            //controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlano));

            //RepositorioOrm - LocadoraAutomoveisOrmDB
            //Plano
            var contextoDadosOrm = new LocadoraAutomoveisDbContext();
            var repositorioPlanoOrm = new RepositorioPlanoOrm(contextoDadosOrm);
            var servicoPlanoOrm = new ServicoPlano(repositorioPlanoOrm, contextoDadosOrm);
            controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlanoOrm));
        }
    }
}
