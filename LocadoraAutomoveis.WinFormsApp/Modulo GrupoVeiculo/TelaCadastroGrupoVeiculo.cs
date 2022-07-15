using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        private GrupoVeiculo grupoVeiculo;

        public Func<GrupoVeiculo, Result<GrupoVeiculo>> GravarRegistro
        {
            get; set;
        }

        public GrupoVeiculo GrupoVeiculo
        {
            get
            {
                return grupoVeiculo;
            }
            set
            {
                grupoVeiculo = value;

                tbNomeGrupoVeiculo.Text = grupoVeiculo.Nome;

            }
        }

        public TelaCadastroGrupoVeiculo()
        {
            InitializeComponent();
        }

        private void TelaCadastroGrupoVeiculo_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            grupoVeiculo.Nome = tbNomeGrupoVeiculo.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbNomeGrupoVeiculo.Clear();
        }

        private void TelaCadastroGrupoVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
            ValidadorCampos.ImpedirTextoMenorDois(tbNomeGrupoVeiculo.Text);
        }
    }
}
