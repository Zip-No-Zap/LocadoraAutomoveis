using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.Modulo_Funcionario
{
    [TestClass]
    public class ValidadorFuncionarioDominioTests
    {
        [TestMethod]
        public void nome_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Nome = "";

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Nome' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void salario_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Salario = 0;

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Salário' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void login_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Login = "";

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Login' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void senha_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Senha = "";

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Senha' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void cidade_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Cidade = "";

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Cidade' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void estado_funcionario_nao_pode_ser_vazio()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Estado = "";

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Estado' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void perfil_funcionario_nao_pode_ser_nulo()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.Perfil = null;

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Perfil' não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void data_admissao_funcionario_nao_pode_ser_menor_que_1753()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.DataAdmissao = Convert.ToDateTime("1/1/1752");

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Data de Admissão' deve ser maior que 1/1/1753", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void data_admissao_funcionario_nao_pode_ser_maior_que_atual()
        {
            var funcionario = InstanciarFuncionario();

            funcionario.DataAdmissao = Convert.ToDateTime("25/06/2022");

            ValidadorFuncionario validaFuncionario = new();

            ValidationResult resultado = validaFuncionario.Validate(funcionario);

            Assert.AreEqual("'Data de Admissão' deve ser menor que hoje", resultado.Errors[0].ErrorMessage);
        }

        Funcionario InstanciarFuncionario()
        {
            return new Funcionario()
            {
                Id = 1,
                Nome = "Joao Kleber",
                Salario = 2.400,
                Login = "jojo124",
                Senha = "jojo2010",
                Cidade = "Sao joao do Ibirapuera",
                Estado = "SP",
                Perfil = "Usuário Geral",
                DataAdmissao = Convert.ToDateTime("20/06/2022")

            };
        }
    }
}
