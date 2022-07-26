using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.Infra.Logs;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
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
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
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

            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioGrupoVeiculo = new RepositorioGrupoVeiculoEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var repositorioVeículo = new RepositorioVeiculoEmBancoDados();
            //var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //var repositorioPlano = new RepositorioPlanoEmBancoDados();

            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
           /* var servicoGrupoVeiculo = new ServicoGrupoVeiculo(repositorioGrupoVeiculo)*/;
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            //var servicoVeiculo = new ServicoVeiculo(repositorioVeículo);
            //var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            //var servicoPlano = new ServicoPlano(repositorioPlano);

            controladores.Add("Funcionário", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("Cliente", new ControladorCliente(servicoCliente));
            //controladores.Add("Grupo de Veículo", new ControladorGrupoVeiculo(servicoGrupoVeiculo));
            controladores.Add("Condutor", new ControladorCondutor(servicoCondutor, servicoCliente));
            //controladores.Add("Veículo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));
            //controladores.Add("Taxa", new ControladorTaxa(servicoTaxa));
            //controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlano));



            //RepositorioOrm - LocadoraAutomoveisOrmDB
            var configuracao = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("ConfiguracaoAplicacao.json")
                          .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            var contextoDadosOrm = new LocadoraAutomoveisDbContext(connectionString);
            
            //Plano
            var repositorioPlanoOrm = new RepositorioPlanoOrm(contextoDadosOrm);
            var servicoPlanoOrm = new ServicoPlano(repositorioPlanoOrm, contextoDadosOrm);
            controladores.Add("Plano de Cobrança", new ControladorPlano(servicoPlanoOrm));
            //=============================================================================

            //Taxa
            var repositorioTaxaOrm = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxaOrm = new ServicoTaxa(repositorioTaxaOrm, contextoDadosOrm);
            controladores.Add("Taxa", new ControladorPlano(servicoTaxaOrm));
            //=============================================================================

            //GrupoVeiculo
            
            var repositorioGrupoVeiculoOrm = new RepositorioGrupoVeiculoOrm(contextoDadosOrm);
            var servicoGrupoVeiculoOrm = new ServicoGrupoVeiculo(repositorioGrupoVeiculoOrm, contextoDadosOrm);
            controladores.Add("Grupo de Veículo", new ControladorGrupoVeiculo(servicoGrupoVeiculoOrm));
            //=============================================================================

            //Veiculo
            var repositorioVeiculoOrm = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculoOrm = new ServicoVeiculo(repositorioVeiculoOrm, contextoDadosOrm);
            controladores.Add("Veículo", new ControladorVeiculo(servicoVeiculoOrm, servicoGrupoVeiculoOrm));
            //=============================================================================
        }
    }
}
