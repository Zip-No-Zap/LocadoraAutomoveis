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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ClienteLocacao_Nome", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CondutorLocacao_Nome", HeaderText = "Condutor Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CondutorLocacao_Cnh", HeaderText = "Condutor CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "VeiculoLocacao_Modelo", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "VeiculoLocacao_Grupo", HeaderText = "Grupo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacaoString", HeaderText = "Data Locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoString", HeaderText = "Data Devolução"},
                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoLocacao_Descricao", HeaderText = "Plano"},
            };

            return colunas;
        }

        public Guid ObtemNumeroLocacaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> registros)
        {
            grid.DataSource = registros;
        }
    }
}
