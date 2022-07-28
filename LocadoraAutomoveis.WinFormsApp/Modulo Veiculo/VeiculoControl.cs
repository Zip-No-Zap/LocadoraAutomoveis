using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public partial class VeiculoControl : UserControl
    {
        public VeiculoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo Combustível"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade"},
                new DataGridViewTextBoxColumn { DataPropertyName = "NomeGrupo", HeaderText = "Grupo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "StatusVeiculo", HeaderText = "Status"},
                new DataGridViewTextBoxColumn { DataPropertyName = "QuilometragemAtual", HeaderText = "Quilometragem Atual"},
                new DataGridViewImageColumn { DataPropertyName = "Foto", HeaderText = "Foto", ImageLayout = DataGridViewImageCellLayout.Stretch, Width = 50}
            };

            return colunas;
        }

        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.DataSource = veiculos;
        }
    }
}
