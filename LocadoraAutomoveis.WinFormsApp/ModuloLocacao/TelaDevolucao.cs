using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.Infra.Logs;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

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
        public double diario_valorPoKmRodado;
        public double diario_valorDiario;
        public double livre_valorDiario;
        public double controlado_valorDiario;
        public double controlado_valorKmRodado;
        public float controlado_limiteKm;
        public double totalPrevisto;
        public string plano;
        public string tipoCombustivel;
        public string nivelTanque;
        public float  tanqueMaximoVeiculo;
        public double diferencaTanque;
        public double diferencaKm;
        public double diasAtraso = 0;
        public double calcPlano;

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

        public double CalcularMultaDevolucaoAtraso()
        {
            var dataDevolvido = dpDataDevolvido.Value;
            var diferenca = (dataDevolvido - dataDevolucaoLocacao).TotalDays;

            if (diferenca >= 1)
            {
                var totalTemp = totalDeFato * 0.10;

                diasAtraso = totalTemp;
                return totalTemp;
            }
            else
                return 0;
        }

        public double CalcularDiferencaQuilometragem()
        {
            double diferenca = 0;
            double totalTemp = 0;
            double total = 0;

            quilometragemAtualizada = float.Parse(txtKmAtualDevolucao.Text);

            if (quilometragemAtualizada >= quilometragemAnterior)
            {
                if (plano != "Livre")
                {
                    diferenca = quilometragemAtualizada - quilometragemAnterior;
                    totalTemp = diferenca * diario_valorPoKmRodado;
                    total += totalTemp;
                }
            }
            else
            {
                MessageBox.Show("Quilometragem de retorno inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }
        
            if (plano == "Controlado" && diferenca > controlado_limiteKm)
            {
                totalTemp = totalTemp * 0.10;
                total += totalTemp;
            }

            diferencaKm = total;
            return total;
        }

        public double CalcularConsumoTanque()
        {
            string porcentagemTanqueString = cmbTanque.Text.Split("%")[0].ToString().Trim();
            int porcentagemTanque = int.Parse(porcentagemTanqueString);
            int deduzir = 100 - porcentagemTanque;
            double divisao = (double)Decimal.Divide(deduzir, 100);
            double tanqueDeduzido = tanqueMaximoVeiculo * divisao;
            double valor = 0;

            if(tipoCombustivel == "Gasolina")
               valor = precoGasolina * tanqueDeduzido;

            if (tipoCombustivel == "Diesel")
                valor = precoDiesel * tanqueDeduzido;

            if (tipoCombustivel == "Álcool")
                valor = precoAlcool * tanqueDeduzido;

            diferencaTanque = valor;
            return valor;
        }

        public double CalcularValorDiarioPlano()
        {
            var dataDevolvido = dpDataDevolvido.Value;

            TimeSpan intervalo = dataDevolvido - dataLocacao;

            int diferenca = Convert.ToInt32(intervalo.Days);

            double resultado = diario_valorDiario * diferenca;

            calcPlano = resultado;
            return resultado;
        }
    }
}
