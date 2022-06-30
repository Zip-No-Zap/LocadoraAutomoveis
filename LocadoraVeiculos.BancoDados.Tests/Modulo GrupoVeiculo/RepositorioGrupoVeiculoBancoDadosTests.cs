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
            repoGrupoVeiculo.Excluir(grupo);

            //assert
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo.Id);

            Assert.IsNull(grupoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            //arrange
            GrupoVeiculo grupo1 = InstanciarGrupoVeiculo();
            GrupoVeiculo grupo2 = InstanciarGrupoVeiculo2();

            repoGrupoVeiculo.Inserir(grupo1);
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
            return new GrupoVeiculo()
            {
                Nome = "Uber"
  
            };
        }

        GrupoVeiculo InstanciarGrupoVeiculo2()
        {
            return new GrupoVeiculo()
            {
                Nome = "Uber22"

            };
        }




        #endregion
    }
}
