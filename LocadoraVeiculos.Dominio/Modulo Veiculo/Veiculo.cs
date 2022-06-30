using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.Modulo_Veiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo()
        {

        }

        public Veiculo(string modelo, string placa, string cor, int ano, string tipoCombustivel, int capacidade, string status, int quilometragem)
        {
            Modelo = modelo;
            Placa = placa;
            Cor = cor;
            Ano = ano;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidade;
            StatusVeiculo = status;
            QuilometragemAtual = quilometragem;

        }
        public string Modelo { get; set; }

        public string Placa { get; set; }

        public string Cor { get; set; }

        public int Ano { get; set; }

        public string TipoCombustivel { get; set; }

        public int CapacidadeTanque { get; set; }

        public GrupoVeiculo GrupoPertencente { get; set; }

        public string StatusVeiculo { get; set; }

        public int QuilometragemAtual { get; set; }


    }
}
