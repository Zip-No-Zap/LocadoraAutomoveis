using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Dominio.Tests
{
    [TestClass]
    public class ValidadorTaxaDominioTests
    {
        [TestMethod]
        public void NaoDeve_servazio_descricao()
        {
            //arrange
            var taxa = InstanciarTaxa();

            taxa.Descricao = "";

            ValidadorTaxa validaTaxa = new();

            //action
            ValidationResult resultado = validaTaxa.Validate(taxa);

            //assert
            Assert.AreEqual("'Descrição' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void NaoDeve_serzeroumenos_valor()
        {
            //arrange
            var taxa = InstanciarTaxa();

            taxa.Valor = 0;

            ValidadorTaxa validaTaxa = new();

            //action
            ValidationResult resultado = validaTaxa.Validate(taxa);

            //assert
            Assert.AreEqual("'Valor' não pode ser zero ou menos", resultado.Errors[0].ErrorMessage);
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
