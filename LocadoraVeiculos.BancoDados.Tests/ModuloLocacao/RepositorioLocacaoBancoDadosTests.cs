using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoBancoDadosTests
    {
        RepositorioCondutorOrm repositorioCondutor;
        RepositorioClienteOrm repositorioCliente;
        RepositorioTaxaOrm repositorioTaxa;
        RepositorioGrupoVeiculoOrm repositorioGrupo;
        RepositorioVeiculoOrm repositorioVeiculo;
        RepositorioPlanoOrm repositorioPlano;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioLocacaoBancoDadosTests()
        {
            dbContext = new(connectionString);
            repositorioCondutor = new(dbContext);
            repositorioCliente = new(dbContext);
            repositorioTaxa = new(dbContext);
            repositorioGrupo = new(dbContext);
            repositorioVeiculo = new(dbContext);
            repositorioPlano = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_locacao()
        {
            //arrange
            var locacao = InstanciarLocacao();
            
            //action
         
            //assert
        }

        [TestMethod]
        public void Deve_editar_locacao()
        {
            //arrange
           
            //action
         
            //assert
        }

        [TestMethod]
        public void Deve_excluir_locacao()
        {
            //arrange
           
            //action
      
            //assert
        }

        [TestMethod]
        public void Deve_selecionar_todos()
        {
            //arrange


            //action


            //assert

        }
        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
           
            //action

            //assert
        }

        private Locacao InstanciarLocacao()
        {
            GrupoVeiculo grupo = new() { Nome = "GrupoTeste" };
            Veiculo veiculo = new()
            {
                Modelo = "ModeloTeste",
                Placa = "MEU3344",
                QuilometragemAtual = 284756,
                GrupoPertencente = grupo,
                Cor = "Branco",
                Ano = 2000,
                CapacidadeTanque = 123,
                Foto = new byte[] { },
                StatusVeiculo = "Disponível",
                TipoCombustivel = "Gasolina",
            };
            Plano plano = new()
            {
                Grupo = grupo,
                LimiteQuilometragem_Controlado = 1234567,
                ValorDiario_Controlado = 200,
                ValorPorKm_Controlado = 100,
                ValorDiario_Diario = 170,
                ValorPorKm_Diario = 60,
                ValorDiario_Livre = 120
            };
            Taxa taxa = new()
            {
                Descricao = "DescriçãoTeste",
                Tipo = "Fixo",
                Valor = 34
            };
            Cliente cliente = new()
            {
                Cpf = "051.655.040-40",
                Email = "teste@gmail.com",
                Endereco = "Endereço Teste",
                Nome = "Nome Cliente Teste",
                Telefone = "(49) 999208754",
                TipoCliente = EnumTipoCliente.PessoaFisica
            };
            Condutor condutor = new()
            {
                Cliente = cliente,
                Cnh = "0987654321",
                Cpf = cliente.Cpf,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                VencimentoCnh = Convert.ToDateTime("20/12/2025")
            };

            return new()
            {
                PlanoLocacao = plano,
                ClienteLocacao = cliente,
                CondutorLocacao = condutor,
                DataLocacao = DateTime.Today,
                DataDevolucao = Convert.ToDateTime("20/10/2022"),
                Grupo = grupo,
                ItensTaxa = new() {taxa},
                Status = "Aberto",
                VeiculoLocacao = veiculo
            };
        }
    }
}
