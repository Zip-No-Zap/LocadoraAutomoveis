﻿using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Cliente
{
    public partial class ClienteControl : UserControl
    {
        public ClienteControl()
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
            new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "Cpf"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "Cnpj"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "Cnh"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Cidade", HeaderText = "Cidade"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereco"},
            new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
            };

            return colunas;
        }

        public int ObtemNumerClienteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Cliente> registros)
        {
            grid.DataSource = registros;
        }
    }
}