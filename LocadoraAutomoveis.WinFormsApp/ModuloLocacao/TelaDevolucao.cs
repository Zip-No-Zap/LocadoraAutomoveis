using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System.Windows.Forms;
using System;
using LocadoraAutomoveis.Infra.Logs;
using System.Collections.Generic;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaDevolucao : Form
    {
        List<Configuracao> confs;
        Configuracao configuracao;
        Serializador serializador;
        double precoGasolina;
        double precoDiesel;
        double precoAlcool;

        public DateTime dataLocacao;
        public DateTime dataDevolucaoLocacao;
        public DateTime dataDevolvido;
        public double totalDeFato = 0;
        public float quilometragemAnterior;
        public float quilometragemAtualizada;
        public double valorPoKmRodado;
        public double valorDiario;
        public float limiteKm;
        public double totalPrevisto;
        public string plano;
        public string tipoCombustivel;
        public string nivelTanque;
        public float tanqueMaximoVeiculo;

        public TelaDevolucao()
        {
            InitializeComponent();
            
            ObterPrecoCombustiveis();
            
        }

        private void ObterPrecoCombustiveis()
        {
            confs = new();
            configuracao = new();
            serializador = new(confs);
            confs = serializador.ObterArquivo();
            configuracao = confs[0];

            precoGasolina = Convert.ToDouble(configuracao.valorGasolina);
            precoDiesel = Convert.ToDouble(configuracao.valorDiesel);
            precoAlcool = Convert.ToDouble(configuracao.valorAlcool);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dataDevolvido = dpDataDevolvido.Value;
            nivelTanque = cmbTanque.Text;

            Validar();
  
            quilometragemAtualizada = float.Parse(txtKmAtualDevolucao.Text);

            if (plano != "Livre")
                totalDeFato += CalcularDiferencaQuilometragem();

            totalDeFato += CalcularValorDiarioPlano();

            totalDeFato += CalcularConsumoTanque();

            totalDeFato += totalPrevisto;

            totalDeFato += CalcularMultaDevolucaoAtraso();
        }

        private void Validar()
        {
            if (ValidarDataRetorno() == false)
            {
                MessageBox.Show("Data de Retorno inválida", "Aviso");
                DialogResult = DialogResult.None;
            }

            if (txtKmAtualDevolucao.Text == "")
            {
                MessageBox.Show("Quilometragem de Retorno inválida", "Aviso");
                DialogResult = DialogResult.None;
            }
        }

        private bool ValidarDataRetorno()
        {
            if (dataDevolvido < dataLocacao)
                return false;

            return true;
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

            if (dataDevolvido >= dataDevolucaoLocacao)
            {
                var totalTemp = totalDeFato * 0.10;
                return totalTemp;
            }
            else
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
                MessageBox.Show("Quilometragem de retorno inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }

            return 0;
        }

        private double CalcularConsumoTanque()
        {
            string porcentagemTanqueString = cmbTanque.Text.Split("%")[0].ToString().Trim();
            int porcentagemTanque = int.Parse(porcentagemTanqueString);
            int deduzir = 100 - porcentagemTanque;
            double tanqueDeduzido = tanqueMaximoVeiculo * (deduzir / 100);
            double valor = 0;

            if(tipoCombustivel == "Gasolina")
               valor = precoGasolina * tanqueDeduzido;

            if (tipoCombustivel == "Diesel")
                valor = precoDiesel * tanqueDeduzido;

            if (tipoCombustivel == "Álcool")
                valor = precoAlcool * tanqueDeduzido;

            return valor;
        }

        private double CalcularValorDiarioPlano()
        {
            var dataDevolvido = dpDataDevolvido.Value;

            TimeSpan intervalo = dataDevolvido - dataLocacao;

            int diferenca = Convert.ToInt32(intervalo.Days);

            double resultado = valorDiario * diferenca;

            return resultado;
        }
    }
}
