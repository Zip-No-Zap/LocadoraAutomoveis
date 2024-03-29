﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxa;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Taxa
{
    [TestClass]
    public class RepositorioTaxaBancoDadosTests
    {
        readonly RepositorioTaxaOrm repoTaxa;
        LocadoraAutomoveisDbContext dbContext;
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LocadoraAutomoveisOrmDBTestes;Integrated Security=True";

        public RepositorioTaxaBancoDadosTests()
        {
            dbContext = new(connectionString);
            repoTaxa = new(dbContext);
        }

        [TestMethod]
        public void Deve_inserir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();
            taxa.Descricao = "teste05";

            //action
            repoTaxa.Inserir(taxa);
            dbContext.SaveChanges();

            //assert
            var resultado = repoTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa);
            dbContext.SaveChanges();


            taxa.Descricao = "alterado no teste";

            //action
            repoTaxa.Editar(taxa);
            dbContext.SaveChanges();


            //assert
            var resultado = repoTaxa.SelecionarPorId(taxa.Id);

            Assert.AreEqual(taxa.Descricao, resultado.Descricao);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

            repoTaxa.Inserir(taxa);
            dbContext.SaveChanges();


            //action
            repoTaxa.Excluir(taxa);
            dbContext.SaveChanges();


            //assert
            var resultado = repoTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_taxa()
        {
            //arrange
            var taxa1 = InstanciarTaxa();
            var taxa2 = InstanciarTaxa2();

            repoTaxa.Inserir(taxa1);
            repoTaxa.Inserir(taxa2);
            dbContext.SaveChanges();


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
            dbContext.SaveChanges();

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

        Taxa InstanciarTaxa2()
        {
            return new Taxa()
            {
                Descricao = "descrição teste2222",
                Tipo = "Fixo",
                Valor = 250
            };
        }

        #endregion
    }
}
