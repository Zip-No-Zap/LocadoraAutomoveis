using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System.Windows.Forms;
using System;


namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaDevolucao : Form
    {
        public DateTime dataLocacao;
        public double totalDeFato = 0;
        public float quilometragemAnterior;
        public float quilometragemAtualizada;
        public double valorPoKmRodado;
        public double valorDiario;
        public string plano;
        public float limiteKm;
        public double totalPrevisto;
        public string tipoCombustivel;
        public float tanqueMaximoVeiculo;

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

            quilometragemAtualizada = float.Parse(txtKmAtualDevolucao.Text);

            if (plano != "Livre")
                totalDeFato += CalcularDiferencaQuilometragem();

            totalDeFato += CalcularValorDiarioPlano();

            totalDeFato += CalcularConsumoTanque();

            totalDeFato += totalPrevisto;

            totalDeFato += CalcularMultaDevolucaoAtraso();
        }

        private void txtKmAtualDevolucao_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void TelaDevolucao_Load(object sender, EventArgs e)
        {
            cmbTanque.SelectedIndex = 0;
        }

        private double CalcularMultaDevolucaoAtraso()
        {
            var dataDevolvido = dpDataDevolvido.Value;

            if (dataDevolvido >= dataLocacao)
            {
                var totalTemp = totalDeFato * 0.10;
                return totalTemp;
            }
            else
            {
                MessageBox.Show("Data de devolução inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }

            return 0;
        }

        private double CalcularDiferencaQuilometragem()
        {
            double diferenca = 0;
            double totalTemp = 0;

            float KmDevolvido = float.Parse(txtKmAtualDevolucao.Text);

            if (KmDevolvido >= quilometragemAnterior)
            {
                diferenca = KmDevolvido - quilometragemAnterior;
                totalTemp = diferenca * valorPoKmRodado;
                return totalTemp;
            }
            else if (plano == "Controlado" && diferenca > limiteKm)
            {
                totalTemp = totalDeFato * 0.10;
                return totalTemp;
            }
            else
            {
                MessageBox.Show("Data de devolução inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }

            return 0;
        }

        private double CalcularConsumoTanque()
        {
            int porcentagemTanque = int.Parse(cmbTanque.Text.Split("%").ToString().Trim());
            int deduzir = 100 - porcentagemTanque;
            double tanqueDeduzido = tanqueMaximoVeiculo * (deduzir / 100);
            double valor = 0;

            if(tipoCombustivel == "Gasolina")
               valor = 6.50 * tanqueDeduzido;

            if (tipoCombustivel == "Diesel")
                valor = 7.55 * tanqueDeduzido;

            return valor;
        }

        private double CalcularValorDiarioPlano()
        {
            var dataDevolvido = dpDataDevolvido.Value;
            int dataLocacaoConvertida = Convert.ToInt32(dataLocacao.Day);
            int dataDevolvidoConvertida = Convert.ToInt32(dataDevolvido.Day);

            int diferenca = dataLocacaoConvertida - dataDevolvidoConvertida;

            return diferenca * valorDiario;
        }
    }
}
