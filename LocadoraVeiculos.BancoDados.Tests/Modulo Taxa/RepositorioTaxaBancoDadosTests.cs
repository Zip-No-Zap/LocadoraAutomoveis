using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Taxa
{
    [TestClass]
    public class RepositorioTaxaBancoDadosTests
    {
        RepositorioTaxaEmBancoDados repoTaxa;

        public RepositorioTaxaBancoDadosTests()
        {
            repoTaxa = new();
        }

        [TestMethod]
        public void Deve_inserir_taxa()
        {
            //arrange
            var taxa = InstanciarTaxa();

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

#endregion
    }
}
