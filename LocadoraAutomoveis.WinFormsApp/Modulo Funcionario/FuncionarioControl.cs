using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class FuncionarioControl : UserControl
    {
        public FuncionarioControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salario"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataString", HeaderText = "Data Admissão"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cidade", HeaderText = "Cidade"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Perfil", HeaderText = "Perfil"},
            };

            return colunas;
        }

        public int ObtemNumerFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.DataSource = funcionarios;
        }
    }
}
