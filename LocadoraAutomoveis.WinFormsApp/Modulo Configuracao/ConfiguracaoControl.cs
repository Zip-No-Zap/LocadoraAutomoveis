using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using LocadoraAutomoveis.Infra.Logs;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public partial class ConfiguracaoControl : UserControl
    {
        private readonly Configuracao conf;
        private readonly List<Configuracao> config = new();
        private readonly ConfiguracaoLogger configuracaologger;
        private Serializador gravador;

        public ConfiguracaoControl()
        {
            InitializeComponent();

            conf = new();

            ObterTextosNoTextBox();
        }

        private void ObterTextosNoTextBox()
        {
            gravador = new(config);
            var configuracoes = gravador.ObterArquivo(@"C:\Temp\");
            var conf = configuracoes[0];

            txbGasolina.Text = conf.valorGasolina;
            txbDiesel.Text = conf.valorDiesel;
            txbAlcool.Text = conf.valorAlcool;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            conf.valorGasolina =  txbGasolina.Text;
            conf.valorDiesel = txbDiesel.Text;
            conf.valorAlcool = txbAlcool.Text;

            config.Add(conf);

            gravador = new(config);
            gravador.GuardarArquivo();
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
