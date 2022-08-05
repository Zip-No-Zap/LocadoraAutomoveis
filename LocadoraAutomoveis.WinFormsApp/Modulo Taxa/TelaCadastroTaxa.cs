using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using FluentResults;
using System;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public partial class TelaCadastroTaxa : Form
    {
        private Taxa taxa;

        public Func<Taxa, Result<Taxa>> GravarRegistro
        {
            get; set;
        }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = value;

                tbDescricao.Text = taxa.Descricao;
                cbTipo.Text = taxa.Tipo;
                tbValor.Text = taxa.Valor.ToString("N2");
            }
        }
        public TelaCadastroTaxa()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbDescricao.Clear();
            tbValor.Clear();
            cbTipo.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            taxa.Descricao = tbDescricao.Text;
            taxa.Tipo = cbTipo.Text;
            taxa.Valor = float.Parse(tbValor.Text);

            Result<Taxa> resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void tbDescricao_Leave(object sender, EventArgs e)
        {
            if (tbDescricao.Text.Length < 2)
            {
                tbDescricao.Clear();
            }
        }

        private void tbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImpedirLetrasCharEspeciais(e);
        }

        private static void ImpedirLetrasCharEspeciais(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void tbDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImpedirNumerosECharsEspeciaisTextBox(e);
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
