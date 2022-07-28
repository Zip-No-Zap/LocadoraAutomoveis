using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Veiculo
{

    [TestClass]
    public class RepositorioVeiculoBancoDadosTests
    {
        readonly RepositorioGrupoVeiculoOrm repoGrupo;
        readonly RepositorioVeiculoOrm repoVeiculo;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioVeiculoBancoDadosTests()
        {
            dbContext = new(connectionString);
            repoGrupo = new(dbContext);
            repoVeiculo = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();
            repoGrupo.Inserir(veiculo.GrupoPertencente);
            dbContext.SaveChanges();

            //action
            repoVeiculo.Inserir(veiculo);
            dbContext.SaveChanges();

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();

            repoGrupo.Inserir(veiculo.GrupoPertencente);

            repoVeiculo.Inserir(veiculo);

            dbContext.SaveChanges();

            veiculo.Modelo = "Tobata bimotor";

            //action
            repoVeiculo.Editar(veiculo);
            dbContext.SaveChanges();

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.AreEqual(veiculo.Modelo, resultado.Modelo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();

            repoGrupo.Inserir(veiculo.GrupoPertencente);
            repoVeiculo.Inserir(veiculo);
            dbContext.SaveChanges();

            //action
            repoVeiculo.Excluir(veiculo);
            dbContext.SaveChanges();

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            //arrange
            var veiculo1 = InstanciarVeiculo();
            var veiculo2 = InstanciarVeiculo2();

            repoGrupo.Inserir(veiculo1.GrupoPertencente);
            repoVeiculo.Inserir(veiculo1);
            repoVeiculo.Inserir(veiculo2);
            dbContext.SaveChanges();

            //action
            var resultado = repoVeiculo.SelecionarTodos(true);

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var veiculo1 = InstanciarVeiculo();

            repoGrupo.Inserir(veiculo1.GrupoPertencente);
            repoVeiculo.Inserir(veiculo1);
            dbContext.SaveChanges();

            //action
            var resultado = repoVeiculo.SelecionarPorId(veiculo1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados

        Veiculo InstanciarVeiculo()
        {
            return new Veiculo()
            {
                Modelo = "Lamborghini Gallardo",
                Placa = "MAB2021",
                Cor = "Vermelho",
                Ano = 2019,
                TipoCombustivel = "Gásolina",
                CapacidadeTanque = 45,
                GrupoPertencente = new("Esportivos"),
                StatusVeiculo = "Disponível",
                QuilometragemAtual = 10000,
                Foto = new byte[] {   }
            };
        }

        Veiculo InstanciarVeiculo2()
        {
            return new Veiculo()
            {
                Modelo = "Ferrari La ferrari",
                Placa = "SAE1256",
                Cor = "Vermelho",
                Ano = 2020,
                TipoCombustivel = "Gásolina",
                CapacidadeTanque = 50,
                GrupoPertencente = new("Esportivos"),
                StatusVeiculo = "Disponível",
                QuilometragemAtual = 1000,
                Foto = new byte[] { }
            };
        }

        #endregion
    }
}
