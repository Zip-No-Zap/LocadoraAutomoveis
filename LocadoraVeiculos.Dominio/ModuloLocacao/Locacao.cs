
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System.Collections.Generic;
using System;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Condutor;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Condutor CondutorLocacao { get; set; }
        public Veiculo VeiculoLocacao { get; set; }
        public List<Taxa> ItensTaxa { get; set; }
        public Plano PlanoLocacao { get; set; }

        public Guid PlanoLocacaoId { get; set; }
        public Guid VeiculoLocacaoId { get; set; }
        public Guid ClienteLocacaoId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        // para usar no LocacaoControl
        public string CondutorLocacao_Nome => CondutorLocacao.Nome;
        public string CondutorLocacao_Cnh => CondutorLocacao.Cnh.ToString();
        public string VeiculoLocacao_Modelo => VeiculoLocacao.Modelo;
        public string VeiculoLocacao_Grupo => VeiculoLocacao.GrupoPertencente.Nome;
        public string PlanoLocacao_Descricao => 
       



        public Locacao(Condutor condutorLocacao, Veiculo veiculoLocacao, List<Taxa> itensTaxa, Plano plano, Guid veiculoLocacaoId, Guid clienteLocacaoId, DateTime dataLocacao, DateTime dataDevolucao)
        {
            CondutorLocacao = condutorLocacao;
            VeiculoLocacao = veiculoLocacao;
            ItensTaxa = itensTaxa;
            PlanoLocacao = plano;
            VeiculoLocacaoId = veiculoLocacaoId;
            ClienteLocacaoId = clienteLocacaoId;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
        }
    }
}
