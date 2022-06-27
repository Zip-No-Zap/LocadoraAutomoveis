using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Cliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        RepositorioClienteEmBancoDados repositorioCliente;

        public RepositorioClienteEmBancoDadosTest()
        {
            repositorioCliente = new RepositorioClienteEmBancoDados();
            ResetarBancoDadosCliente();
        }

        [TestMethod]
        public void Deve_inserir_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorioCliente.Inserir(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();
            repositorioCliente.Inserir(cliente);

            cliente.Nome = "Ana Beatriz";

            //action
            var resultado = repositorioCliente.Editar(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = InstanciarCliente();
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            //action
            var resultado = repositorioCliente.Excluir(clienteSelecionado);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_selecionar_todos()
        {
            //arrange


            //action
            var resultado = repositorioCliente.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        private void ResetarBancoDadosCliente()
        {

            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }
        private Cliente InstanciarCliente()
        {
            
            return new Cliente()
            {
                Nome = "Ana",
                Cpf = "12345678978",
                Cnpj = "-",
                Cnh = "123123123123",
                Email = "anabeatriz@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "11923121231",
            };
        }

    }
}
