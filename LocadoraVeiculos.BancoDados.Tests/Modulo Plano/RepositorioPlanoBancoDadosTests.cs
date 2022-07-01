using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Plano;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Plano
{
    [TestClass]
    public class RepositorioPlanoBancoDadosTests
    {

       RepositorioPlanoEmBancoDados repoPlano;

        public RepositorioPlanoBancoDadosTests()
        {
            repoPlano = new();

            ResetarBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            Plano funcionario = InstanciarPlano();

            //action
            repoPlano.Inserir(funcionario);

            //assert
            var resultado = repoPlano.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionario = InstanciarPlano();
            repoPlano.Inserir(funcionario);
           
            Plano funcionarioSelecionado = repoPlano.SelecionarPorId(funcionario.Id);

            funcionarioSelecionado.Nome = "Foi alterado no teste";
            funcionarioSelecionado.Salario = 9000;

            //action
            repoPlano.Editar(funcionarioSelecionado);

            //assert
            var resultado = repoPlano.SelecionarPorId(funcionarioSelecionado.Id);

            Assert.AreEqual(funcionarioSelecionado, resultado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = InstanciarPlano();

            repoPlano.Inserir(funcionario);

            //action
            repoPlano.Excluir(funcionario);

            //assert
            var resultado = repoPlano.SelecionarPorId(funcionario.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionarTodos_funcionario()
        {
            //arrange
            var func1 = InstanciarPlano();
            var func2 = InstanciarPlano2();

            repoPlano.Inserir(func1); 
            repoPlano.Inserir(func2); 

            //action
            var resultado = repoPlano.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }


        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var func1 = InstanciarPlano();

            repoPlano.Inserir(func1);

            //action
            var resultado = repoPlano.SelecionarPorId(func1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados

        Plano InstanciarPlano()
        {
            return = new()
            {
                Descricao = "Livre", // Diário e Controlado
                ValorDiario = 120,
                ValorPorKm = 150,
                LimiteQuilometragem = 150,

                Grupo = new()
                {
                    Nome = "Econômico"
                }
            };
        }

        Plano InstanciarPlano2()
        {
            return = new()
            {
                Descricao = "Controlado", // Diário e Livre
                ValorDiario = 250,
                ValorPorKm = 300,
                LimiteQuilometragem = 265,

                Grupo = new()
                {
                    Nome = "Uber"
                }
            };
        }

        void ResetarBancoDados()
        {
            DbTests.ExecutarSql("DELETE FROM TBPLANO; DBCC CHECKIDENT (TBPLANO, RESEED, 0)");
        }


        #endregion

      
    }
}
