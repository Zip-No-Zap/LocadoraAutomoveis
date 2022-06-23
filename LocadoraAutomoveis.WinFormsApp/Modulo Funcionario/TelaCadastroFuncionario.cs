﻿using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario;

        public Func<Funcionario, ValidationResult> GravarRegistro
        {
            get; set;
        }

        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }
            set
            {
                funcionario = value;

                tbNome.Text = funcionario.Nome;
                tbSalario.Text = funcionario.Salario.ToString();
                tbData.Text = funcionario.DataAdmissao.ToString();
                tbCidade.Text = funcionario.Cidade;
                cbUF.Text = funcionario.Estado;
                tbLogin.Text = funcionario.Login;
                tbSenha.Text = funcionario.Senha;
                cbPerfil.Text = funcionario.Perfil;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tbSenha.PasswordChar = '*';
            tbSenha.MaxLength = 14;
        }

        private void TelaCadasrtoFuncionario_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            funcionario.Nome = tbNome.Text;
            funcionario.Salario = float.Parse(tbSalario.Text);
            funcionario.DataAdmissao = Convert.ToDateTime(tbData.Text);
            funcionario.Cidade = tbCidade.Text;
            funcionario.Estado = cbUF.Text;
            funcionario.Login = tbLogin.Text;
            funcionario.Senha = tbSenha.Text;
            funcionario.Perfil = cbPerfil.Text;

            ValidationResult resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbSalario.Clear();
            tbData.Clear();
            tbCidade.Clear();
            tbLogin.Clear();
            tbSenha.Clear();

            tbNome.Focus();
        }

        private void TelaCadasrtoFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ImpedirNumeroTexBox(e);
        }

        private void tbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ImpedirNumeroTexBox(e);
        }

        private void tbSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImpedirLetrasCharEspeciais(e);
        }

        private void tbData_Leave(object sender, EventArgs e)
        {
            DateTime convertido = Convert.ToDateTime(tbData.Text);

            if (convertido > DateTime.Today)
            {
                MessageBox.Show("Data de admissão não pode ser maior que hoje", "Aviso");
                tbData.Focus();
                return;
            }
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
           // ImpedirTextoMenorDois(tbNome.Text);
            //tbNome.Focus();
        }

        private void ImpedirTextoMenorDois(string texto)
        {
            //if(Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57)
            //e.Handled = true;
            //e = null;
        }

        private static void ImpedirLetrasCharEspeciais(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbCidade_Leave(object sender, EventArgs e)
        {
            //ImpedirTextoMenorDois(tbCidade.Text);
            //tbCidade.Focus();
        }

        private static KeyPressEventArgs ImpedirNumeroTexBox(KeyPressEventArgs e)
        {
            if ((Strings.Asc(e.KeyChar) >= 48 & Strings.Asc(e.KeyChar) <= 57))
            {
                e.Handled = true;
                e = null;
            }

            return e;
        }
    }
}
