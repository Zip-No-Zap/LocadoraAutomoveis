﻿using LocadoraVeiculos.Dominio.Modulo_Cliente;
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


        public ValidadorClienteDominioTest()
        {
            

        }
        [TestMethod]
        public void Nome_cliente_deve_ser_obrigatorio()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaFisica.Nome = null;
            clientePessoaJuridica.Nome = null;

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual(false, resultadoPessoaFisica);
            Assert.AreEqual(false, resultadoPessoaJuridica);
        }
        [TestMethod]
        public void Telefone_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaFisica.Telefone = "iiiii";
            clientePessoaJuridica.Telefone = "iiiiii";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoTelefone = validador.Validate(clientePessoaFisica);
          

            //assert
            Assert.AreEqual("'Telefone' com formato incorreto.", resultadoTelefone.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Email_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaFisica.Email = "email@";
            clientePessoaJuridica.Email = "email.com";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoEmail = validador.Validate(clientePessoaFisica);


            //assert
            Assert.AreEqual("'Email' formato incorreto", resultadoEmail.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cpf_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            clientePessoaFisica.Cpf = "234.234";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);

            //assert
            Assert.AreEqual("'CPF' com formato incorreto.", resultadoPessoaFisica.Errors[0].ErrorMessage);

        }
        [TestMethod]
        public void Cnpj_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaJuridica.Cnpj = "234224";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("'CNPJ' com formato incorreto.", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        }
        [TestMethod]
       

        private Cliente InstanciarClientePessoaFisica()
        {

            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "12345678985",
                Cnpj = "",
                Cnh = "123123123123",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(11)92312-1231",
                TipoCliente = EnumTipoCliente.PessoaFisica

            };
        }
        private Cliente InstanciarClientePessoaJuridica()
        {
            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "453333444455",
                Cnpj = "12345678901234",
                Cnh = "123456789098",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(11)92312-1231",
                //TipoCliente = EnumTipoCliente.PessoaJuridica
            };
        }
    }
}
