using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual("Campo 'Nome' é obrigatório.", resultadoPessoaFisica.Errors[0].ErrorMessage);
            Assert.AreEqual("Campo 'Nome' é obrigatório.", resultadoPessoaJuridica.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void Telefone_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
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
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaFisica.Cpf = null;
            clientePessoaFisica.Email = "email@";
            clientePessoaJuridica.Email = "email.com";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("'Email' formato incorreto", resultadoPessoaFisica.Errors[0].ErrorMessage);
            Assert.AreEqual("'Email' formato incorreto", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void Cpf_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaFisica = InstanciarClientePessoaFisica();
            clientePessoaFisica.Cpf = "2908098908098098912";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaFisica = validador.Validate(clientePessoaFisica);

            //assert
            Assert.AreEqual("'CPF' inválido.", resultadoPessoaFisica.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void Cnpj_deve_ter_um_formato_valido()
        {
            //arrange
            var clientePessoaJuridica = InstanciarClientePessoaJuridica();
            clientePessoaJuridica.Cpf = null;
            clientePessoaJuridica.Cnpj = "234224709709709870988709709870987980";

            ValidadorCliente validador = new ValidadorCliente();

            //action
            var resultadoPessoaJuridica = validador.Validate(clientePessoaJuridica);

            //assert
            Assert.AreEqual("'CNPJ' inválido.", resultadoPessoaJuridica.Errors[0].ErrorMessage);

        }

        #region privates

        private Cliente InstanciarClientePessoaFisica()
        {

            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "12345678985",
                Cnpj = "",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "11923121231",
                TipoCliente = EnumTipoCliente.PessoaFisica

            };
        }
        private Cliente InstanciarClientePessoaJuridica()
        {
            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "",
                Cnpj = "11155599988877",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(11)92312-1231",
                //TipoCliente = EnumTipoCliente.PessoaJuridica
            };
        }

        #endregion
    }
}
