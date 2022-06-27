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
            ResetarBancoDadosFuncionario();
        }

        [TestMethod]
        public void Deve_inserir_funcionario()
        {
            //arrange
            Funcionario funcionario = InstanciarFuncionario();

            //action
            var resultado = repoFunc.Inserir(funcionario);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_editar_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();
            Funcionario selecionado = repoFunc.SelecionarPorId(funcionario.Id);

            funcionario.Nome = "Foi alterado no teste";
            funcionario.Salario = 9000;

            funcionarioSelecionado.Nome = "Foi alterado no teste";
            funcionarioSelecionado.Salario = 9000;

            //action
            var resultado = repoFunc.Editar(funcionarioSelecionado);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_excluir_funcionario()
        {
            //arrange
            var funcionario = InstanciarFuncionario();

            repoFunc.Inserir(funcionario);

            //action
            var resultado = repoFunc.Excluir(funcionario);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
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

        private void ResetarBancoDadosFuncionario()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }


        #endregion
    }
}
