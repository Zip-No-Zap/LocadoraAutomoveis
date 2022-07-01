using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public partial class PlanoControl : UserControl
    {
        public PlanoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "NomeGrupo", HeaderText = "Grupo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario", HeaderText = "Valor Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm", HeaderText = "Valor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteQuilometragem", HeaderText = "Limite Quilometragem"},
            };

            return colunas;
        }

        public int ObtemNumerPlanoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Plano> registro)
        {
            grid.DataSource = registro;
        }
    }
}
