﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.ModuloPlano;
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
        readonly RepositorioGrupoVeiculoOrm repoGrupo;
        readonly RepositorioPlanoOrm repoPlano;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioPlanoBancoDadosTests()
        {
            dbContext = new(connectionString);
            repoGrupo = new(dbContext);
            repoPlano = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_plano()
        {
            //arrange
            Plano plano = InstanciarPlano();
           
            repoGrupo.Inserir(plano.Grupo);
            dbContext.SaveChanges();

            //action
            repoPlano.Inserir(plano);
            dbContext.SaveChanges();

            //assert
            var resultado = repoPlano.SelecionarPorId(plano.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_plano()
        {
            //arrange
            var plano = InstanciarPlano();
         

            repoGrupo.Inserir(plano.Grupo);
            repoPlano.Inserir(plano);
            dbContext.SaveChanges();

            Plano planoSelecionado = repoPlano.SelecionarPorId(plano.Id);

            planoSelecionado.ValorDiario_Diario = 9000;

            //action
            repoPlano.Editar(planoSelecionado);
            dbContext.SaveChanges();

            //assert
            var resultado = repoPlano.SelecionarPorId(planoSelecionado.Id);

            Assert.AreEqual(planoSelecionado.ValorDiario_Diario, resultado.ValorDiario_Diario);
        }

        [TestMethod]
        public void Deve_excluir_plano()
        {
            //arrange
            var plano = InstanciarPlano();
         
            repoGrupo.Inserir(plano.Grupo);
            repoPlano.Inserir(plano);
            dbContext.SaveChanges();

            //action
            repoPlano.Excluir(plano);
            dbContext.SaveChanges();

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
        
            repoGrupo.Inserir(plano1.Grupo);
            plano2.Grupo = plano1.Grupo;
            repoPlano.Inserir(plano1); 
            repoPlano.Inserir(plano2);
            dbContext.SaveChanges();

            //action
            var resultado = repoPlano.SelecionarTodos(true);

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var plano = InstanciarPlano();

            repoGrupo.Inserir(plano.Grupo);
            repoPlano.Inserir(plano);
            dbContext.SaveChanges();

            //action
            var resultado = repoPlano.SelecionarPorId(plano.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados

        Plano InstanciarPlano()
        {
            return new()
            {
                Grupo = InstanciarGrupoVeiculo(),
                ValorDiario_Diario = 50,
                ValorPorKm_Diario = 35,

                ValorDiario_Livre = 30,

                ValorDiario_Controlado = 20,
                ValorPorKm_Controlado = 130,
                LimiteQuilometragem_Controlado = 200
            };
        }

        Plano InstanciarPlano2()
        {
            return new()
            {
                Grupo = InstanciarGrupoVeiculo(),
                ValorDiario_Diario = 550,
                ValorPorKm_Diario = 535,

                ValorDiario_Livre = 530,

                ValorDiario_Controlado = 520,
                ValorPorKm_Controlado = 330,
                LimiteQuilometragem_Controlado = 500
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
            return new GrupoVeiculo("GrupoTeste")
            {
            };
        }

        #endregion


    }
}
