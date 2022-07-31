using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System.Windows.Forms;
using System;


namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaDevolucao : Form
    {
        public DateTime dataLocacao;
        public double totalDeFato;
        public float quilometragemAnterior;
        public double valorPoKmRodado;
        public string plano;
        public float limiteKm;

        public TelaDevolucao()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(ValidadorCampos.ValidarCampoData(dpDataDevolvido.Text) == false)
            {
                MessageBox.Show("Data de devolução inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }

            if (plano != "Livre")
                CalcularDiferencaQuilometragem();
        }

        private void txtKmAtualDevolucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void TelaDevolucao_Load(object sender, EventArgs e)
        {
            cmbTanque.SelectedIndex = 0;
        }

        private void CalcularMultaDevolucaoAtraso()
        {
            var dataDevolvido = dpDataDevolvido.Value;

            if (dataDevolvido >= dataLocacao)
            {
                var totalTemp = totalDeFato * 0.10;
                totalDeFato += totalTemp;
            }
            else
            {
                MessageBox.Show("Data de devolução inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }
        }

        private void CalcularDiferencaQuilometragem()
        {
            float KmDevolvido = float.Parse(txtKmAtualDevolucao.Text);

            if (KmDevolvido >= quilometragemAnterior)
            {
                var diferenca = KmDevolvido - quilometragemAnterior;
                var totalTemp = diferenca * valorPoKmRodado;
                totalDeFato += totalTemp;

                if (plano == "Controlado" && diferenca > limiteKm)
                {
                    totalTemp = totalDeFato * 0.10;
                    totalDeFato += totalTemp;
                }
            }
            else
            {
                MessageBox.Show("Data de devolução inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
