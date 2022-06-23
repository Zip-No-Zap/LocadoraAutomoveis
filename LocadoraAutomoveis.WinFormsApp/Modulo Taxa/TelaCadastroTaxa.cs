using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public partial class TelaCadastroTaxa : Form
    {
        private Taxa taxa;

        public Func<Taxa, ValidationResult> GravarRegistro
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
                tbValor.Text = taxa.Valor.ToString();
            }
        }
        public TelaCadastroTaxa()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

            ValidationResult resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }
    }
}
