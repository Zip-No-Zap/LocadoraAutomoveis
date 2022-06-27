using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
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
            ResetarBancoDados();
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
            repositorioCliente.Inserir(cliente);
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
            var cliente1 = InstanciarCliente();

            repositorioCliente.Inserir(cliente1);

            var cliente2 = InstanciarCliente2();

            repositorioCliente.Inserir(cliente2);
            //action
            var resultado = repositorioCliente.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }


        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var cliente1 = InstanciarCliente();

            repositorioCliente.Inserir(cliente1);

            //action
            var resultado = repositorioCliente.SelecionarPorId(cliente1.Id);

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

        private Cliente InstanciarCliente2()
        {

            return new Cliente()
            {
                Nome = "Luis B",
                Cpf = "11111111111",
                Cnpj = "-",
                Cnh = "111111111111",
                Email = "luish@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(49)99106130",
            };
        }

        void ResetarBancoDados()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");
        }

    }
}
