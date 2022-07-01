using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Plano;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Plano
{
    [TestClass]
    public class RepositorioPlanoBancoDadosTests
    {

       RepositorioPlanoEmBancoDados repoPlano;
        RepositorioGrupoVeiculoEmBancoDados repoGrupo;

        public RepositorioPlanoBancoDadosTests()
        {
            repoPlano = new();
            repoGrupo = new();

            ResetarBancoDados();
            ResetarBancoDadosGrupo();
        }

        [TestMethod]
        public void Deve_inserir_plano()
        {
            //arrange
            Plano plano = InstanciarPlano();
            var grupo = InstanciarGrupoVeiculo();

            //action
            repoGrupo.Inserir(grupo);
            repoPlano.Inserir(plano);

            //assert
            var resultado = repoPlano.SelecionarPorId(plano.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_plano()
        {
            //arrange
            var plano = InstanciarPlano();
            repoPlano.Inserir(plano);
           
            Plano planoSelecionado = repoPlano.SelecionarPorId(plano.Id);

            planoSelecionado.Descricao = "Foi alterado no teste";
            planoSelecionado.ValorDiario = 9000;

            //action
            repoPlano.Editar(planoSelecionado);

            //assert
            var resultado = repoPlano.SelecionarPorId(planoSelecionado.Id);

            Assert.AreEqual(planoSelecionado, resultado);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            var plano = InstanciarPlano();

            repoPlano.Inserir(plano);

            //action
            repoPlano.Excluir(plano);

            //assert
            var resultado = repoPlano.SelecionarPorId(plano.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionarTodos_plano()
        {
            //arrange
            var plano1 = InstanciarPlano();
            var plano2 = InstanciarPlano2();

            repoPlano.Inserir(plano1); 
            repoPlano.Inserir(plano2); 

            //action
            var resultado = repoPlano.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }


        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var plano1 = InstanciarPlano();

            repoPlano.Inserir(plano1);

            //action
            var resultado = repoPlano.SelecionarPorId(plano1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados

        Plano InstanciarPlano()
        {
            return new()
            {
                Descricao = "Livre", // Diário e Controlado
                ValorDiario = 120,
                ValorPorKm = 150,
                LimiteQuilometragem = 450,

                Grupo = new()
                {
                    Id = 1,
                    Nome = "Econômico"
                }
            };
        }

        Plano InstanciarPlano2()
        {
            return new()
            {
                Descricao = "Controlado", // Diário e Livre
                ValorDiario = 250,
                ValorPorKm = 300,
                LimiteQuilometragem = 265,

                Grupo = new()
                {
                    Id = 1,
                    Nome = "Uber"
                }
            };
        }

        void ResetarBancoDados()
        {
            DbTests.ExecutarSql("DELETE FROM TBPLANO; DBCC CHECKIDENT (TBPLANO, RESEED, 0)");
        }

        void ResetarBancoDadosGrupo()
        {
            DbTests.ExecutarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }

        GrupoVeiculo InstanciarGrupoVeiculo()
        {
            return new GrupoVeiculo()
            {
                Nome = "Uber"
            };
        }

        #endregion


    }
}
