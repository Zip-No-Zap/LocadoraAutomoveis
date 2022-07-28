using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.BancoDados.Tests
{
    [TestClass]
    public class RepositorioGrupoVeiculoBancoDadosTests
    {
        RepositorioGrupoVeiculoOrm repoGrupoVeiculo;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioGrupoVeiculoBancoDadosTests()
        {
            dbContext = new(connectionString);
            repoGrupoVeiculo = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            //action
            repoGrupoVeiculo.Inserir(grupo);
            dbContext.SaveChanges();

            //assert
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            repoGrupoVeiculo.Inserir(grupo);

            grupo.Nome = "Foi alterado no teste";

            //action
            repoGrupoVeiculo.Editar(grupo);
            dbContext.SaveChanges();

            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            //assert
            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo.Id, grupoEncontrado.Id);
            Assert.AreEqual(grupo.Nome, grupoEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_excluir_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();
            repoGrupoVeiculo.Inserir(grupo);
            
            //action
            repoGrupoVeiculo.Excluir(grupo);
            dbContext.SaveChanges();

            //assert
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            Assert.IsNull(grupoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            //arrange
            GrupoVeiculo grupo1 = InstanciarGrupoVeiculo();
            repoGrupoVeiculo.Inserir(grupo1);
            
            GrupoVeiculo grupo2 = InstanciarGrupoVeiculo2();
            repoGrupoVeiculo.Inserir(grupo2);


            //action
            var grupos = repoGrupoVeiculo.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, grupos.Count);
        }

        [TestMethod]
        public void Deve_selecionar_por_id_grupo()
        {
            
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();
            grupo.Nome = "teste04";

            repoGrupoVeiculo.Inserir(grupo);

            //action
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            //assert
            Assert.IsNotNull(grupoEncontrado);
        }

        #region privados

        GrupoVeiculo InstanciarGrupoVeiculo()
        {
            return new GrupoVeiculo("Econômico")
            {
  
            };
        }

        GrupoVeiculo InstanciarGrupoVeiculo2()
        {
            return new GrupoVeiculo("Esportivo")
            {

            };
        }

        #endregion
    }
}
