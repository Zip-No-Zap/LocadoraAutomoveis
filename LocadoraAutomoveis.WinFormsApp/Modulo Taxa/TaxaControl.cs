using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public partial class TaxaControl : UserControl
    {
        public TaxaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},
            };

            return colunas;
        }

        public Guid ObtemNumeroTaxaSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Taxa> registro)
        {
            grid.DataSource = registro;
        }
    }
}
