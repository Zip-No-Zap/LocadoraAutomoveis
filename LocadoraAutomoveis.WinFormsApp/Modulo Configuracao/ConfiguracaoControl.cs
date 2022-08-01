using FluentResults;
using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public partial class ConfiguracaoControl : UserControl
    {
        private Configuracao configuracao;
        public ConfiguracaoControl()
        {
            InitializeComponent();
        }

        public Func<Configuracao, Result<Configuracao>> GravarRegistro
        {
            get; set;
        }

        public Configuracao GrupoVeiculo
        {
            get
            {
                return configuracao;
            }
            set
            {
                configuracao = value;

                txbGasolina.Text = configuracao.valorGasolina;
                txbDiesel.Text = configuracao.valorDiesel;

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            configuracao.valorGasolina = txbGasolina.Text;
            configuracao.valorDiesel = txbDiesel.Text;

            var resultadoValidacao = GravarRegistro(configuracao);

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbGasolina.Clear();
            txbDiesel.Clear();
        }

        private void txbDiesel_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImpedirLetrasCharEspeciais(e);
        }

        private void txbGasolina_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
