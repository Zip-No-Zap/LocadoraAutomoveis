using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.BancoDados.Tests
{
    [TestClass]
    public class RepositorioGrupoVeiculoBancoDadosTests
    {
        RepositorioGrupoVeiculoEmBancoDados repoGrupoVeiculo;

        public RepositorioGrupoVeiculoBancoDadosTests()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
            repoGrupoVeiculo = new();
            InstanciarGrupoVeiculo();
        }

        [TestMethod]
        public void Deve_inserir_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            //action
            repoGrupoVeiculo.Inserir(grupo);

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

            //action
            var resultado = repoGrupoVeiculo.Excluir(grupo);

            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            //assert
            Assert.IsNull(grupoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            repoGrupoVeiculo.Inserir(grupo);

            var grupos = repoGrupoVeiculo.SelecionarTodos();

            Assert.AreEqual(1, grupos.Count);
        }

        [TestMethod]
        public void Deve_selecionar_um_grupo()
        {
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();
            grupo.Nome = "teste04";
            grupo.Id = 1000;

            repoGrupoVeiculo.Inserir(grupo);

            //action
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            //assert
            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);

        }

        #region privados

        GrupoVeiculo InstanciarGrupoVeiculo()
        {
            return new GrupoVeiculo()
            {
                Id = 1,
                Nome = "Uber"
  
            };
        }
            

        #endregion
    }
}
