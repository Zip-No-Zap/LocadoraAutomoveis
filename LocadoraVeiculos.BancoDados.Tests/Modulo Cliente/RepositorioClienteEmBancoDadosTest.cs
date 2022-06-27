using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Cliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        RepositorioClienteEmBancoDados repositorioCliente ;

        public RepositorioClienteEmBancoDadosTest()
        {
            repositorioCliente = new RepositorioClienteEmBancoDados();
        }
        [TestMethod]
        public void Deve_inserir_cliete()
        {
            // arrange
            var cliente = InstanciarCliente();

            //action
            var resultado = repositorioCliente.Inserir(cliente);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }
        [TestMethod]
        public void Deve_editar_cliete()
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
            Cliente cliente = repositorioCliente.SelecionarPorId(5);

            //action
            var resultado = repositorioCliente.Excluir(cliente);

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


            //action
            var resultado = repositorioCliente.SelecionarPorId(3);

            //assert
            Assert.AreNotEqual(null, resultado);
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
