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

        string sql_insercao => @"INSERT INTO TBGRUPOVEICULO 
                                                    (
                                                        [NOMEGRUPO]   
                                                    )
                                                    VALUES
                                                    (
                                                        @NOMEGRUPO

                                                    );SELECT SCOPE_IDENTITY();";
        string sql_edicao => @"UPDATE [TBGRUPOVEICULO] SET 

                                                    [NOMEGRUPO] = @NOMEGRUPO    
                                               WHERE
                                                    ID = @ID";
        string sql_exclusao => @"DELETE FROM TBGRUPOVEICULO WHERE ID = @ID;";
        string sql_selecao_por_id => @"SELECT * FROM TBGRUPOVEICULO WHERE ID = @ID";
        string sql_selecao_todos => @"SELECT * FROM TBGRUPOVEICULO";

        public RepositorioGrupoVeiculoBancoDadosTests()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
            repoGrupoVeiculo = new();
            InstanciarGrupoVeiculo();
        }

        [TestMethod]
        public void Deve_inserir_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            //action
            repoGrupoVeiculo.Inserir(grupo, sql_insercao);

            //assert

            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo, sql_selecao_por_id);

            Assert.IsNotNull(grupoEncontrado);
            Assert.AreEqual(grupo, grupoEncontrado);
        }

        [TestMethod]
        public void Deve_editar_grupo()
        {
            //arrange
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            repoGrupoVeiculo.Inserir(grupo, sql_insercao);

            grupo.Nome = "Foi alterado no teste";
            

            //action
            repoGrupoVeiculo.Editar(grupo, sql_edicao);

            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo, sql_selecao_por_id);

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
            var resultado = repoGrupoVeiculo.Excluir(grupo, sql_exclusao);

            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo, sql_selecao_por_id);

            //assert
            Assert.IsNull(grupoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_grupos()
        {
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();

            repoGrupoVeiculo.Inserir(grupo, sql_insercao);

            var grupos = repoGrupoVeiculo.SelecionarTodos(sql_selecao_todos);

            Assert.AreEqual(1, grupos.Count);
        }

        [TestMethod]
        public void Deve_selecionar_um_grupo()
        {
            GrupoVeiculo grupo = InstanciarGrupoVeiculo();
            grupo.Nome = "teste04";
            grupo.Id = 1000;

            repoGrupoVeiculo.Inserir(grupo, sql_insercao);

            //action
            GrupoVeiculo grupoEncontrado = repoGrupoVeiculo.SelecionarPorId(grupo, sql_selecao_por_id);

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
