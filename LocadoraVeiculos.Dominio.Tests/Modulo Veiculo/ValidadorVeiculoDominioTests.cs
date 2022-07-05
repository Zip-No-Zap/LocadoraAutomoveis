using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Dominio.Tests.Modulo_Veiculo
{
    [TestClass]
    public class ValidadorVeiculoDominioTests
    {
        [TestMethod]

        public void modelo_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.Modelo = "";

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'Modelo' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void placa_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.Placa = "";

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'Placa' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void cor_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.Cor = "";

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'Cor' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void ano_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.Ano = 0;

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'Ano' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void tipo_combustivel_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.TipoCombustivel = "";

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'TipoCombustivel' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void capacidade_tanque_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.CapacidadeTanque = 0;

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'CapacidadeTanque' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void grupo_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.GrupoPertencente = null;

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'GrupoPertencente' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void status_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.StatusVeiculo = "";

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'StatusVeiculo' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void quilometragem_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.QuilometragemAtual = 0;

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'QuilometragemAtual' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        #region Instancia de Veiculo

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
                GrupoPertencente = new("Esportivos"),
                StatusVeiculo = "Disponível",
                QuilometragemAtual = 10000,
                Foto = new byte[] { }

            };
        }

        #endregion
    }
}
