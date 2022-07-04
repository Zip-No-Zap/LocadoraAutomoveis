using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual("'Tipo Combustivel' não pode ser vazio", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Capacidade Tanque' não pode ser vazio", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Grupo Pertencente' não pode ser vazio", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Status Veiculo' não pode ser vazio", resultado.Errors[0].ErrorMessage);
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
            Assert.AreEqual("'Quilometragem Atual' não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void foto_nao_pode_ser_vazio()
        {
            var veiculo = InstanciarVeiculo();

            veiculo.Foto = null;

            ValidadorVeiculo validaVeiculo = new();

            //action
            ValidationResult resultado = validaVeiculo.Validate(veiculo);

            //assert
            Assert.AreEqual("'Foto' não pode ser vazio", resultado.Errors[0].ErrorMessage);
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

            };
        }

        #endregion
    }
}
