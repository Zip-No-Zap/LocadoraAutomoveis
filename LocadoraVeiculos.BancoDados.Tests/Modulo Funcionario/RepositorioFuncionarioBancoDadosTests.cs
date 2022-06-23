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
            Assert.AreEqual(funcionario, resultado);
        }

        #region privados

        Funcionario InstanciarFuncionario()
        {
            return new Funcionario()
            {
                Nome = "nome teste",
                Cidade = "cidade teste",
                Estado = "estado teste",
                Salario = 123456,
                DataAdmissao = DateTime.Parse("12/12/2021"),
                Login = "login teste",
                Senha = "senha teste"
            };
        }
            

        #endregion
    }
}
