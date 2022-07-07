using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Veiculo
{

    [TestClass]
    public class RepositorioVeiculoBancoDadosTests
    {
        RepositorioVeiculoEmBancoDados repoVeiculo;
        RepositorioGrupoVeiculoEmBancoDados repoGrupo;

        public RepositorioVeiculoBancoDadosTests()
        {
            repoVeiculo = new();
            repoGrupo = new();
            ResetarBancoDadosPlano();
            ResetarBancoDadosVeiculo();
            ResetarBancoDadosGrupo();
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();
            repoGrupo.Inserir(veiculo.GrupoPertencente);

            //action
            repoVeiculo.Inserir(veiculo);

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

            veiculo.Modelo = "Tobata bimotor";

            //action
            repoVeiculo.Editar(veiculo);

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

            //action
            repoVeiculo.Excluir(veiculo);

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

            //action
            var resultado = repoVeiculo.SelecionarTodos();

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

            //action
            var resultado = repoVeiculo.SelecionarPorId(veiculo1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);

            ResetarBancoDadosVeiculo();
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
                GrupoPertencente = new("Esportivos") { Id = 1 },
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
                GrupoPertencente = new("Esportivos") { Id = 1 },
                StatusVeiculo = "Disponível",
                QuilometragemAtual = 1000,
                Foto = new byte[] { }
            };
        }

        void ResetarBancoDadosVeiculo()
        {
            DbTests.ExecutarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT (TBVEICULO, RESEED, 0)");
        }

        void ResetarBancoDadosGrupo()
        {
            DbTests.ExecutarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }

        void ResetarBancoDadosPlano()
        {
            DbTests.ExecutarSql("DELETE FROM TBPLANO; DBCC CHECKIDENT (TBPLANO, RESEED, 0)");
        }
        #endregion
    }
}
