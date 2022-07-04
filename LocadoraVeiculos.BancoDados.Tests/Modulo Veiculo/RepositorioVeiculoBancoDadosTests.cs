﻿using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.BancoDados.Tests.Modulo_Veiculo
{
    [TestClass]
    public class RepositorioVeiculoBancoDadosTests
    {
        RepositorioVeiculoEmBancoDados repoVeiculo;

        public RepositorioVeiculoBancoDadosTests()
        {
            repoVeiculo = new();
            ResetarBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();
            veiculo.Modelo = "Audio A8";

            //action
            repoVeiculo.Inserir(veiculo);

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void Deve_editar_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo(); 

            repoVeiculo.Inserir(veiculo);

            veiculo.Modelo = "Tobata bimotor";

            //action
            repoVeiculo.Editar(veiculo);

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.AreEqual(veiculo.Modelo, resultado.Modelo);
        }

        [TestMethod]
        public void Deve_excluir_veiculo()
        {
            //arrange
            var veiculo = InstanciarVeiculo();

            repoVeiculo.Inserir(veiculo);

            //action
            repoVeiculo.Excluir(veiculo);

            //assert
            var resultado = repoVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNull(resultado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_veiculos()
        {
            //arrange
            var veiculo1 = InstanciarVeiculo();
            var veiculo2 = InstanciarVeiculo2();

            repoVeiculo.Inserir(veiculo1);
            repoVeiculo.Inserir(veiculo2);

            //action
            var resultado = repoVeiculo.SelecionarTodos();

            //assert
            Assert.AreNotEqual(0, resultado.Count);
        }

        [TestMethod]
        public void Deve_selecionar_unico()
        {
            //arrange
            var veiculo1 = InstanciarVeiculo();

            repoVeiculo.Inserir(veiculo1);

            //action
            var resultado = repoVeiculo.SelecionarPorId(veiculo1.Id);

            //assert
            Assert.AreNotEqual(null, resultado);
        }

        #region privados
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

        Veiculo InstanciarVeiculo2()
        {
            return new Veiculo()
            {
                Modelo = "Ferrari La ferrari",
                Placa = "SAE1256",
                Cor = "Vermelho",
                Ano = 2020,
                TipoCombustivel = "Gásolina",
                CapacidadeTanque = 50,
                GrupoPertencente = new("Esportivos"),
                StatusVeiculo = "Disponível",
                QuilometragemAtual = 1000,
            };
        }

        void ResetarBancoDados()
        {
            DbTests.ExecutarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT (TBVEICULO, RESEED, 0)");
        }
        #endregion
    }
}
