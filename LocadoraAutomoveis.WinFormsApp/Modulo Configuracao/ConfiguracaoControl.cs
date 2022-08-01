using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using LocadoraAutomoveis.Infra.Logs;
using System.Windows.Forms;
using FluentResults;
using System;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public partial class ConfiguracaoControl : UserControl
    {
        private Configuracao configuracao;

        private readonly ConfiguracaoLogger configuracaologger;

        public ConfiguracaoControl(Configuracao configuracao)
        {
            InitializeComponent();

            txbGasolina.Text = configuracao.valorGasolina;
            txbDiesel.Text = configuracao.valorDiesel;
            txbAlcool.Text = configuracao.valorAlcool;
        }

        public Func<Configuracao, Result<Configuracao>> GravarRegistro
        {
            get; set;
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
