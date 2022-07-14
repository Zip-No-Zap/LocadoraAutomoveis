using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.BancoDados.Tests
{
    [TestClass]
    public class RepositorioFuncionarioBancoDadosTests
    {
        RepositorioFuncionarioEmBancoDados repoFunc;

        public RepositorioFuncionarioBancoDadosTests()
        {
            repoFunc = new();

           // ResetarBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            Funcionario funcionario = InstanciarFuncionario();

            //action
            repoFunc.Inserir(funcionario);

            //assert
            var resultado = repoFunc.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();
            repoFunc.Inserir(funcionario);
           
            Funcionario funcionarioSelecionado = repoFunc.SelecionarPorId(funcionario.Id);

            funcionarioSelecionado.Nome = "Foi alterado no teste";
            funcionarioSelecionado.Salario = 9000;

            //action
            repoFunc.Editar(funcionarioSelecionado);

            //assert
            var resultado = repoFunc.SelecionarPorId(funcionarioSelecionado.Id);

            Assert.AreEqual(funcionarioSelecionado, resultado);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();

            repoFunc.Inserir(funcionario);

            //action
            repoFunc.Excluir(funcionario);

            //assert
            var resultado = repoFunc.SelecionarPorId(funcionario.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionarTodos_funcionario()
        {
            //arrange
            var func1 = InstanciarFuncionario();
            var func2 = InstanciarFuncionario2();

            repoFunc.Inserir(func1); 
            repoFunc.Inserir(func2); 

            //action
            var resultado = repoFunc.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }


        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var func1 = InstanciarFuncionario();

            repoFunc.Inserir(func1);

            //action
            var resultado = repoFunc.SelecionarPorId(func1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados

        Funcionario InstanciarFuncionario()
        {
            return new Funcionario()
            {
                Nome = "nome teste",
                Cidade = "cidade teste",
                Estado = "UF",
                Salario = 123456,
                DataAdmissao = DateTime.Parse("12/12/2021"),
                Login = "loginteste",
                Senha = "senhateste",
                Perfil = "Administrador"
                
            };
        }

        Funcionario InstanciarFuncionario2()
        {
            return new Funcionario()
            {
                Nome = "nome teste 2222",
                Cidade = "cidade teste 2222",
                Estado = "sc",
                Salario = 2000,
                DataAdmissao = DateTime.Parse("12/10/2021"),
                Login = "loginteste2222",
                Senha = "senhateste222",
                Perfil = "Administrador"
            };
        }

        void ResetarBancoDados()
        {
            DbTests.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");
        }


        #endregion
    }
}
