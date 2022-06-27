﻿using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Taxa
{
    [TestClass]
    public class RepositorioTaxaBancoDadosTests
    {
        RepositorioTaxaEmBancoDados repoTaxa;
       
        public RepositorioTaxaBancoDadosTests()
        {
            repoTaxa = new();
            ResetarBancoDadosTaxa();
        }

        [TestMethod]
        public void Deve_inserir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();
            taxa.Descricao = "teste05";

            //action
            var resultado = repoTaxa.Inserir(taxa);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_editar_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa);

            taxa.Descricao = "alterado no teste";

            //action
            var resultado = repoTaxa.Editar(taxa);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa);

            //action
            var resultado = repoTaxa.Excluir(taxa);

            //assert
            Assert.AreEqual(true, resultado.IsValid);
        }

        [TestMethod]
        public void Deve_selecionar_todos_taxa()
        {
            //arrange
            var taxa1 = InstanciarTaxa();
            var taxa2 = InstanciarTaxa2();

            repoTaxa.Inserir(taxa1);
            repoTaxa.Inserir(taxa2);

            //action
            var resultado = repoTaxa.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var taxa1 = InstanciarTaxa();

            repoTaxa.Inserir(taxa1);

            //action
            var resultado = repoTaxa.SelecionarPorId(taxa1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }


        #region privados
        Taxa InstanciarTaxa()
        {
            return new Taxa()
            {
                Descricao = "descrição teste",
                Tipo = "Fixo",
                Valor = 120
            };
        }

        private void ResetarBancoDadosTaxa()
        {

            repoTaxa = new();

            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");
        }

        #endregion
    }
}
