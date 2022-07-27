using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Cliente;
using LocadoraAutomoveis.WinFormsApp.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

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

            //var repositorioCliente = new RepositorioClienteEmBancoDados();
            //var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            //var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //var repositorioPlano = new RepositorioPlanoEmBancoDados();
            //var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            //var repositorioGrupoVeiculo = new RepositorioGrupoVeiculoEmBancoDados();
            //var repositorioVeículo = new RepositorioVeiculoEmBancoDados();

            //var servicoCliente = new ServicoCliente(repositorioCliente);
            //var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            //var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            //var servicoPlano = new ServicoPlano(repositorioPlano);
            //var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            //var servicoGrupoVeiculo = new ServicoGrupoVeiculo(repositorioGrupoVeiculo);
            //var servicoVeiculo = new ServicoVeiculo(repositorioVeículo);

            // controladores.Add("Cliente", new ControladorCliente(servicoCliente));
            //controladores.Add("Condutor", new ControladorCondutor(servicoCondutor, servicoCliente));
            //controladores.Add("Taxa", new ControladorTaxa(servicoTaxa));
            //controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlano));
            //controladores.Add("Funcionário", new ControladorFuncionario(servicoFuncionario));
            //controladores.Add("Grupo de Veículo", new ControladorGrupoVeiculo(servicoGrupoVeiculo));
            //controladores.Add("Veículo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));


            //RepositorioOrm - LocadoraAutomoveisOrmDB
            var configuracao = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("ConfiguracaoAplicacao.json")
                          .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            var contextoDadosOrm = new LocadoraAutomoveisDbContext(connectionString);
            
           //repositorios
            var repositorioPlanoOrm = new RepositorioPlanoOrm(contextoDadosOrm);
            var repositorioTaxaOrm = new RepositorioTaxaOrm(contextoDadosOrm);
            var repositorioFuncionarioOrm = new RepositorioFuncionarioOrm(contextoDadosOrm);
            //var repositorioLocacaoOrm = new RepositorioLocacaoOrm(contextoDadosOrm);
            var repositorioVeiculoOrm = new RepositorioVeiculoOrm(contextoDadosOrm);
            var repositorioGrupoVeiculoOrm = new RepositorioGrupoVeiculoOrm(contextoDadosOrm);
            var repositorioClienteOrm = new RepositorioClienteOrm(contextoDadosOrm);
            var repositorioCondutorOrm = new RepositorioCondutorOrm(contextoDadosOrm);
            
            
            //serviços
            var servicoPlanoOrm = new ServicoPlano(repositorioPlanoOrm, contextoDadosOrm);
            var servicoTaxaOrm = new ServicoTaxa(repositorioTaxaOrm, contextoDadosOrm);
            var servicoFuncionarioOrm = new ServicoFuncionario(repositorioFuncionarioOrm, contextoDadosOrm);
            //var servicoLocacaoOrm = new ServicoLocacao(repositorioLocacaoOrm, contextoDadosOrm);
            var servicoVeiculoOrm = new ServicoVeiculo(repositorioVeiculoOrm, contextoDadosOrm);
            var servicoGrupoVeiculoOrm = new ServicoGrupoVeiculo(repositorioGrupoVeiculoOrm, contextoDadosOrm);
            var servicoClienteOrm = new ServicoCliente(repositorioClienteOrm, contextoDadosOrm);
            var servicoCondutorOrm = new ServicoCondutor(repositorioCondutorOrm, contextoDadosOrm);
           

            //controladores
            controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlanoOrm, servicoGrupoVeiculoOrm));
            controladores.Add("Taxa", new ControladorTaxa(servicoTaxaOrm));
            controladores.Add("Funcionário", new ControladorFuncionario(servicoFuncionarioOrm));
            //controladores.Add("Locação", new ControladorLocacao(servicoLocacaoOrm));
            controladores.Add("Veículo", new ControladorVeiculo(servicoVeiculoOrm, servicoGrupoVeiculoOrm));
            controladores.Add("Grupo de Veículo", new ControladorGrupoVeiculo(servicoGrupoVeiculoOrm));
            controladores.Add("Condutor", new ControladorCondutor(servicoCondutorOrm, servicoClienteOrm));
            controladores.Add("Cliente", new ControladorCliente(servicoClienteOrm));
        }
    }
}
