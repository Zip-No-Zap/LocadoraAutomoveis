﻿using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using System;
using System.Collections.Generic;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false},
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "CNPJ"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
            };

            return colunas;
        }

        public Guid ObtemNumerClienteSelecionado() => grid.SelecionarNumero<Guid>();

        public void AtualizarRegistros(List<Cliente> registros)
        {
            grid.DataSource = registros;
        }
    }
}
