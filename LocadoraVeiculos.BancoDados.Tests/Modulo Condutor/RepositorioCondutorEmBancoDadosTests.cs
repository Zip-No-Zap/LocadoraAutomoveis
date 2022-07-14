using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Condutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTests
    {
        RepositorioCondutorEmBancoDados repositorioCondutor;
        RepositorioClienteEmBancoDados repositorioCliente;
        public RepositorioCondutorEmBancoDadosTests()
        {
            repositorioCondutor = new();
            repositorioCliente = new();

            //ResetarBancoDadosCondutor();
            //ResetarBancoDadosCliente();
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            Condutor condutor = InstanciarCondutor();

            //action
            repositorioCondutor.Inserir(condutor);

            //assert
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Deve_editar_condutor()
        {
            //arrange
            Condutor condutor = InstanciarCondutor();
            repositorioCondutor.Inserir(condutor);

            //action
            condutor.Email = "biazinha@gmail.com";
            repositorioCondutor.Editar(condutor);

            //assert
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(resultado);
        }


        [TestMethod]
        public void Deve_excluir_condutor()
        {
            //arrange
            var condutor = InstanciarCondutor();
            repositorioCondutor.Inserir(condutor);
           

            //action
            repositorioCondutor.Excluir(condutor);

            //assert
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNull(resultado);
        }


        #region privates

        private Condutor InstanciarCondutor()
        {
            Cliente cliente = new Cliente()
            {
                Nome = "Felipe Rafael",
                Cpf = "35467859765",
                Cnpj = "-",
                Email = "fr@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(49)99910-6130"
            };
            repositorioCliente.Inserir(cliente);

            return new Condutor()
            {
                Nome = "Ana Beatriz", 
                Cpf = "12332112332",
                Cnh = "1112223334",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC", 
                Cliente = cliente, 
                Telefone = "(11)91234-5678"

            };
        }

        private void ResetarBancoDadosCondutor()
        {
            DbTests.ExecutarSql("DELETE FROM TBCONDUTOR; DBCC CHECKIDENT (TBCONDUTOR, RESEED, 0)");
        }

        private void ResetarBancoDadosCliente()
        {
            DbTests.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");
        }

        #endregion
    }
}
