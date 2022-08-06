using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System.Collections.Generic;
using System;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao.Devolucao
{
    public struct StructDevolucao
    {
        public DateTime dataLocacao;
        public DateTime dataDevolucaoLocacao;
        public DateTime dataDevolvido;
        public double totalDeFato;
        public float quilometragemAnterior;
        public float quilometragemAtualizada;
        public double diario_valorPoKmRodado;
        public double diario_valorDiario;
        public double livre_valorDiario;
        public double controlado_valorDiario;
        public double controlado_valorKmRodado;
        public float controlado_limiteKm;
        public double totalPrevisto;
        public string plano;
        public string tipoCombustivel;
        public string nivelTanque;
        public float tanqueMaximoVeiculo;
        public double diferencaTanque;
        public double diferencaKm;
        public double diasAtraso;
        public double calcPlano;
        public double calcTaxasDiarias;
        
        public List<Taxa> taxasDiarias;

        public double precoGasolina;
        public double precoDiesel;
        public double precoAlcool;

        public StructDevolucao(DateTime dataLocacao, DateTime dataDevolucaoLocacao,
                         DateTime dataDevolvido, double totalDeFato, float quilometragemAnterior,
                         float quilometragemAtualizada, double diario_valorPoKmRodado, double diario_valorDiario,
                         double livre_valorDiario, double controlado_valorDiario, double controlado_valorKmRodado,
                         float controlado_limiteKm, double totalPrevisto, string plano, string tipoCombustivel,
                         string nivelTanque, float tanqueMaximoVeiculo, double diferencaTanque, double diferencaKm,
                         double diasAtraso, double calcPlano, double precoGasolina, double precoDiesel, double precoAlcool,
                         List<Taxa> taxasDiarias)
        {
            this.dataLocacao = dataLocacao;
            this.dataDevolucaoLocacao = dataDevolucaoLocacao;
            this.dataDevolvido = dataDevolvido;
            this.totalDeFato = totalDeFato;
            this.quilometragemAnterior = quilometragemAnterior;
            this.quilometragemAtualizada = quilometragemAtualizada;
            this.diario_valorPoKmRodado = diario_valorPoKmRodado;
            this.diario_valorDiario = diario_valorDiario;
            this.livre_valorDiario = livre_valorDiario;
            this.controlado_valorDiario = controlado_valorDiario;
            this.controlado_valorKmRodado = controlado_valorKmRodado;
            this.controlado_limiteKm = controlado_limiteKm;
            this.totalPrevisto = totalPrevisto;
            this.plano = plano;
            this.tipoCombustivel = tipoCombustivel;
            this.nivelTanque = nivelTanque;
            this.tanqueMaximoVeiculo = tanqueMaximoVeiculo;
            this.diferencaTanque = diferencaTanque;
            this.diferencaKm = diferencaKm;
            this.diasAtraso = diasAtraso;
            this.calcPlano = calcPlano;
            this.precoGasolina = precoGasolina;
            this.precoDiesel = precoDiesel;
            this.precoAlcool = precoAlcool;
            this.taxasDiarias = taxasDiarias;
        }
    }

}
