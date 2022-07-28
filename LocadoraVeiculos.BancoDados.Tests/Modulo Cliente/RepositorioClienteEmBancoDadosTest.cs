using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Cliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        RepositorioClienteOrm repositorioCliente;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioClienteEmBancoDadosTest()
        {
            dbContext = new(connectionString);
            repositorioCliente = new(dbContext);

            // ResetarBancoDadosCondutor();
            // ResetarBancoDadosCliente();
        }
        [TestMethod]
        public void Deve_inserir_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();

            //action
            repositorioCliente.Inserir(cliente);
            dbContext.SaveChanges();

            //assert
            var selecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(selecionado);
        }
        [TestMethod]
        public void Deve_editar_cliente()
        {
            // arrange
            var cliente = InstanciarCliente();
            repositorioCliente.Inserir(cliente);

            cliente.Nome = "Ana Beatriz editado pelo teste";

            //action
            repositorioCliente.Editar(cliente);
            dbContext.SaveChanges();

            //assert
            var selecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.AreEqual(cliente.Nome, selecionado.Nome);
        }
        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = InstanciarCliente();
            repositorioCliente.Inserir(cliente);
            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(cliente.Id);

            //action
            repositorioCliente.Excluir(clienteSelecionado);
            dbContext.SaveChanges();

            //assert
            var selecionado = repositorioCliente.SelecionarPorId(clienteSelecionado.Id);

            Assert.IsNull(selecionado);
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

        [TestMethod]
        public void Deve_selecionar_por_nome()
        {
            //arrange
            var cliente1 = InstanciarCliente();
            repositorioCliente.Inserir(cliente1);

            //action
            var resultado = repositorioCliente.SelecionarPorNome(cliente1.Nome);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        [TestMethod]
        public void Deve_selecionar_por_cpf()
        {
            //arrange
            var cliente1 = InstanciarCliente();
            repositorioCliente.Inserir(cliente1);

            //action
            var resultado = repositorioCliente.SelecionarPorCpf(cliente1.Cpf);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privates

        private Cliente InstanciarCliente()
        {
            
            return new Cliente()
            {
                Nome = "Felipe Rafael",
                Cpf = "35467859765",
                Cnpj = "-",
                Email = "fr@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(49)99910-6130",
            };
        }

        private Cliente InstanciarCliente2()
        {

            return new Cliente()
            {
                Nome = "Luis B",
                Cpf = "05165502929",
                Cnpj = "-",
                Email = "luish@gmail.com",
                Endereco = "Lages - SC",
                Telefone = "(49)99910-6130",
            };
        }

        #endregion

    }
}
