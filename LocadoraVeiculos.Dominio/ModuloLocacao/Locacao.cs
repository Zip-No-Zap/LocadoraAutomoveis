using System;
using System.Collections.Generic;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public string _estaLocado;

        public Condutor CondutorLocacao { get; set; }
        public Cliente ClienteLocacao { get; set; }
        public Veiculo VeiculoLocacao { get; set; }
        public List<Taxa> ItensTaxa { get; set; }
        public Plano PlanoLocacao { get; set; }
        public GrupoVeiculo Grupo { get; set; }

        public Guid PlanoLocacaoId { get; set; }
        public Guid VeiculoLocacaoId { get; set; }
        public Guid ClienteLocacaoId { get; set; }
        public Guid CondutorLocacaoId { get; set; }
        public Guid ItensTaxaId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolvidoDeFato { get; set; }
        public double TotalPrevisto { get; set; }
        public string NivelTanqueVeiculo { get; set; }

        public string Status { get; set; }
        public string CondutorLocacao_Cnh => CondutorLocacao != null ? CondutorLocacao.Cnh.ToString() : "";
        public string PlanoLocacao_Descricao { get; set; }

        public Locacao()
        {
            DataLocacao = DateTime.Today;
            DataDevolucao = DateTime.Today;
            DataDevolvidoDeFato = DateTime.Today;
            ItensTaxa = new();
        }

        public Locacao(Condutor condutorLocacao, Veiculo veiculoLocacao, List<Taxa> itensTaxa, Plano plano, Guid veiculoLocacaoId, Guid clienteLocacaoId, Cliente clienteLocacao) : base()
        {
            CondutorLocacao = condutorLocacao;
            VeiculoLocacao = veiculoLocacao;
            ItensTaxa = itensTaxa;
            PlanoLocacao = plano;
            VeiculoLocacaoId = veiculoLocacaoId;
            ClienteLocacaoId = clienteLocacaoId;
            ClienteLocacao = clienteLocacao;
         }
    }
}
