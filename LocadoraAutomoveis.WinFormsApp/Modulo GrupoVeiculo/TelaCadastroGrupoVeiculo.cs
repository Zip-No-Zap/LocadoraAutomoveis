using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        private GrupoVeiculo grupoVeiculo;

        public Func<GrupoVeiculo, ValidationResult> GravarRegistro
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

            ValidationResult resultadoValidacao = GravarRegistro(grupoVeiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

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
            e = ImpedirNumerosECharsEspeciaisTextBox(e);
        }


        private void tbNome_Leave(object sender, EventArgs e)
        {
            ImpedirTextoMenorDois(tbNomeGrupoVeiculo.Text);
        }

        private void ImpedirTextoMenorDois(string texto)
        {
           if(texto.Length < 2)
            {
                MessageBox.Show("Campo 'Nome' não aceita menos que dois caracteres", "Aviso", MessageBoxButtons.OK);

                return;
            }
        }
        private static KeyPressEventArgs ImpedirNumerosECharsEspeciaisTextBox(KeyPressEventArgs e)
        {
            if ((Strings.Asc(e.KeyChar) >= 48 & Strings.Asc(e.KeyChar) <= 57))
            {
                e.Handled = true;
            }

            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }

            return e;
        }
    }
}
