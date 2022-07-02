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
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Diario", HeaderText = "Plano Diário: Valor Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Diário", HeaderText = "Plano Diário: Valor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Livre", HeaderText = "Plano Livre: Valor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Controlado", HeaderText = "Plano Controlado: Valor Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Controlado", HeaderText = "Plano Controlado: Valor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteQuilometragem_Controlado", HeaderText = "Plano Controlado: Limite Quilometragem"},
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
