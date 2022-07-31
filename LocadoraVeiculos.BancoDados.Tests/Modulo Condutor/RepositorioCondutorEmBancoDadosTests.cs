using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Condutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTests
    {
        RepositorioCondutorOrm repositorioCondutor;
        RepositorioClienteOrm repositorioCliente;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioCondutorEmBancoDadosTests()
        {
            dbContext = new(connectionString);
            repositorioCondutor = new(dbContext);
            repositorioCliente = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_condutor()
        {
            //arrange
            Condutor condutor = InstanciarCondutor();

            //action
            repositorioCondutor.Inserir(condutor);
            dbContext.SaveChanges();

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
            dbContext.SaveChanges();

            condutor.Email = "biazinha@gmail.com";

            //action
            repositorioCondutor.Editar(condutor);
            dbContext.SaveChanges();

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
            dbContext.SaveChanges();

            //action
            repositorioCondutor.Excluir(condutor);
            dbContext.SaveChanges();

            //assert
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionar_todos()
        {
            //arrange
            var condutor = InstanciarCondutor();

            repositorioCondutor.Inserir(condutor);
            dbContext.SaveChanges();

            //action
            var resultado = repositorioCliente.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var condutor = InstanciarCondutor();

            repositorioCondutor.Inserir(condutor);
            dbContext.SaveChanges();

            //action
            var resultado = repositorioCondutor.SelecionarPorId(condutor.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
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

        #endregion
    }
}
