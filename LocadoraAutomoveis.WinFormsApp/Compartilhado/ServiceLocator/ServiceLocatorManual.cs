﻿using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
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
using LocadoraAutomoveis.Infra.Orm.ModuloLocacao;
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
using LocadoraAutomoveis.WinFormsApp.ModuloLocacao;
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
            controladores = new();

            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            return (T)controladores[tipo.Name];
        }

        private void InicializarControladores()
        {

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

            var repositorioLocacaoOrm = new RepositorioLocacaoOrm(contextoDadosOrm);
            var repositorioVeiculoOrm = new RepositorioVeiculoOrm(contextoDadosOrm);
            var repositorioGrupoVeiculoOrm = new RepositorioGrupoVeiculoOrm(contextoDadosOrm);
            var repositorioClienteOrm = new RepositorioClienteOrm(contextoDadosOrm);
            var repositorioCondutorOrm = new RepositorioCondutorOrm(contextoDadosOrm);
            
            
            //serviços
            var servicoPlanoOrm = new ServicoPlano(repositorioPlanoOrm, contextoDadosOrm);
            var servicoTaxaOrm = new ServicoTaxa(repositorioTaxaOrm, contextoDadosOrm);
            var servicoFuncionarioOrm = new ServicoFuncionario(repositorioFuncionarioOrm, contextoDadosOrm);

            var servicoLocacaoOrm = new ServicoLocacao(repositorioLocacaoOrm, contextoDadosOrm);
            var servicoVeiculoOrm = new ServicoVeiculo(repositorioVeiculoOrm, contextoDadosOrm);
            var servicoGrupoVeiculoOrm = new ServicoGrupoVeiculo(repositorioGrupoVeiculoOrm, contextoDadosOrm, repositorioPlanoOrm, repositorioVeiculoOrm);
            var servicoClienteOrm = new ServicoCliente(repositorioClienteOrm, contextoDadosOrm, repositorioCondutorOrm);
            var servicoCondutorOrm = new ServicoCondutor(repositorioCondutorOrm, contextoDadosOrm);
           

            //controladores
            controladores.Add("ControladorPlano", new ControladorPlano(servicoPlanoOrm, servicoGrupoVeiculoOrm));
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxaOrm));
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionarioOrm));

            controladores.Add("Locação", new ControladorLocacao(servicoLocacaoOrm));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculoOrm, servicoGrupoVeiculoOrm));
            controladores.Add("ControladorGrupoVeiculo", new ControladorGrupoVeiculo(servicoGrupoVeiculoOrm));
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutorOrm, servicoClienteOrm));
            controladores.Add("ControladorCliente", new ControladorCliente(servicoClienteOrm));
            
        }
    }
}
