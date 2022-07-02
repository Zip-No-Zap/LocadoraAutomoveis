using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Condutor
{
    public partial class CondutorControl : UserControl
    {
        public CondutorControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "VencimentoCnh", HeaderText = "Vencimento CNH"},

            };

            return colunas;
        }

        public int ObtemNumerCondutorSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Condutor> condutor)
        {
            grid.DataSource = condutor;
        }
    }
}
