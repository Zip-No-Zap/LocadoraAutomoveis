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
                new DataGridViewTextBoxColumn { DataPropertyName = "NomeGrupo", HeaderText = "Grupo Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Diario", HeaderText = "Diário:\nValor diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Diário", HeaderText = "Diário:\nValor por Km rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Livre", HeaderText = "Livre:\nValor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Controlado", HeaderText = "Controlado:\nValor Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Controlado", HeaderText = "Controlado:\nValor por Km rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteQuilometragem_Controlado", HeaderText = "Controlado:\n Limite quilometragem"},
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
