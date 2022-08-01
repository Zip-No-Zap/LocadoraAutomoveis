using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class LocacaoControl : UserControl
    {
        public LocacaoControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false},
                new DataGridViewTextBoxColumn { DataPropertyName = "ClienteLocacao", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CondutorLocacao", HeaderText = "Condutor Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CondutorLocacao", HeaderText = "Condutor CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "VeiculoLocacao", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "VeiculoLocacao", HeaderText = "Grupo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Data Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Data Devolução"},
                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoLocacao_Descricao", HeaderText = "Plano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Situação"},
            };

            return colunas;
        }

        public Guid ObtemNumeroLocacaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> registros)
        {
            grid.Rows.Clear();

            foreach (var registro in registros)
            {
                grid.Rows.Add(
                    registro.Id,
                    registro.ClienteLocacao.Nome,
                    registro.CondutorLocacao.Nome,
                    registro.CondutorLocacao_Cnh,
                    registro.VeiculoLocacao.Modelo,
                    registro.VeiculoLocacao.GrupoPertencente.Nome,
                    registro.DataLocacao.ToShortDateString(),
                    registro.DataDevolucao.ToShortDateString(),
                    registro.PlanoLocacao_Descricao,
                    registro.Status);
            }
        }
    }
}
