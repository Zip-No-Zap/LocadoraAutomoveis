using LocadoraVeiculos.Dominio.Modulo_Funcionario;
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

            //action
            var resultado = repoFunc.Editar(funcionario);

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


            //action
            var resultado = repoFunc.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
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
            

        #endregion
    }
}
