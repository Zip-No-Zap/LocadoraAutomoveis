﻿using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario;

        public Func<Funcionario, Result<Funcionario>> GravarRegistro
        {
            get; set;
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

        public TelaCadastroFuncionario()
        {
            InitializeComponent();
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

            Result<Funcionario> resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbSalario.Clear();
            tbData.Text = "01/01/1753";
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
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void tbCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void tbSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbData_Leave(object sender, EventArgs e)
        {
            if (ValidadorCampos.ValidarCampoData(tbData.Text) == false)
            {
                MessageBox.Show("Data em formato incorreto", "Aviso");
            }
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
            if (tbNome.Text.Length < 2)
            {
                tbNome.Clear();
            }

        }

        private void tbCidade_Leave(object sender, EventArgs e)
        {
            if (tbCidade.Text.Length < 2)
            {
                tbCidade.Clear();
            }
        }

        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidarCampoLogin(e);
        }
    }
}
