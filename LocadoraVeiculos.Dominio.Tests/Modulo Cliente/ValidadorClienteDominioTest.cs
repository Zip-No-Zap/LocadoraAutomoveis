using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Tests.Modulo_Funcionario
{
    [TestClass]
    public class ValidadorClienteDominioTest
    {
        private readonly Cliente clientePessoaFisica;
        private readonly Cliente clientePessoaJuridica;

        public ValidadorClienteDominioTest()
        {
            clientePessoaFisica = new()
            {
                Nome = "Ana",
                Cpf = "12345678978",
                Cnpj = "-",
                Cnh = "1234567891",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(11)92312-1231",
            };
            clientePessoaJuridica = new()
            {
                Nome = "Ana",
                Cpf = "-",
                Cnpj = "1231234564567",
                Cnh = "1234567891",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(11)92312-1231", 
                TipoCliente = (EnumTipoCliente)1
                
            };

        }
        [TestMethod]
        public void Nome_cliente_deve_ser_obrigatorio()
        {
            //arrange
            clientePessoaFisica.Nome = null;
            clientePessoaJuridica.Nome = null;

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("Campo 'Nome' é obrigatório.", resultadoPessoaFisica.Errors[0].ErrorMessage);
            Assert.AreEqual("Campo 'Nome' é obrigatório.", resultadoPessoaJuridica.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void Telefone_deve_ter_um_formato_valido()
        {
            //arrange
            clientePessoaFisica.Telefone = "323423";
            clientePessoaJuridica.Telefone = "4324343";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("'Telefone' com formato incorreto.", resultadoPessoaFisica.Errors[0].ErrorMessage);
            Assert.AreEqual("'Telefone' com formato incorreto.", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Email_deve_ter_um_formato_valido()
        {
            //arrange
            clientePessoaFisica.Email = "email@";
            clientePessoaJuridica.Email = "email.com";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("'Email' com formato incorreto", resultadoPessoaFisica.Errors[0].ErrorMessage);
            Assert.AreEqual("'Email' com formato incorreto", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        }

        //[TestMethod]
        //public void Cpf_deve_ter_um_formato_valido()
        //{
        //    //arrange
        //    clientePessoaFisica.Cpf = "234.234";
        //    clientePessoaJuridica.Cpf = null;

        //    ValidadorCliente validador = new ValidadorCliente();

        //    //action
        //    var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
        //    var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

        //    //assert
        //    Assert.AreEqual("'CPF' com formato incorreto.", resultadoPessoaFisica.Errors[0].ErrorMessage);
        //    Assert.AreEqual("'CPF' com formato incorreto.", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        //}

    }
}
