using LocadoraAutomoveis.WinFormsApp.ModuloLocacao.Devolucao;
using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
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
        public StructDevolucao Devolucao;

        public TelaDevolucao()
        {
            InitializeComponent();
            
            ObterPrecoCombustiveis();

            Devolucao = new();
            Devolucao.totalDeFato = 0;
            Devolucao.diasAtraso = 0;
        }

        private void ObterPrecoCombustiveis()
        {
            confs = new();
            configuracao = new();
            serializador = new(confs);
            confs = serializador.ObterArquivo();
            configuracao = confs[0];

            Devolucao.precoGasolina = Convert.ToDouble(configuracao.valorGasolina);
            Devolucao.precoDiesel = Convert.ToDouble(configuracao.valorDiesel);
            Devolucao.precoAlcool = Convert.ToDouble(configuracao.valorAlcool);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Devolucao.dataDevolvido = dpDataDevolvido.Value;
            Devolucao.nivelTanque = cmbTanque.Text;

            Validar();
  
            Devolucao.totalDeFato += CalcularDiferencaQuilometragem();
            Devolucao.totalDeFato += CalcularValorDiarioPlano();
            Devolucao.totalDeFato += CalcularConsumoTanque();
            Devolucao.totalDeFato += CalcularTaxasDiarias();
            Devolucao.totalDeFato += Devolucao.totalPrevisto;
            Devolucao.totalDeFato += CalcularMultaDevolucaoAtraso();
        }

        public double CalcularMultaDevolucaoAtraso()
        {
            var diferenca = (Devolucao.dataDevolvido - Devolucao.dataDevolucaoLocacao).TotalDays;

            if (diferenca >= 1)
            {
                var totalTemp = Devolucao.totalDeFato * 0.10;

                Devolucao.diasAtraso = totalTemp;
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

            Devolucao.quilometragemAtualizada = float.Parse(txtKmAtualDevolucao.Text);

            if (Devolucao.quilometragemAtualizada >= Devolucao.quilometragemAnterior)
            {
                if (Devolucao.plano != "Livre")
                {
                    diferenca = Devolucao.quilometragemAtualizada - Devolucao.quilometragemAnterior;
                    totalTemp = diferenca * Devolucao.diario_valorPoKmRodado;
                    total += totalTemp;
                }
            }
            else
            {
                MessageBox.Show("Quilometragem de retorno inválida", "Aviso");
                this.DialogResult = DialogResult.None;
            }
        
            if (Devolucao.plano == "Controlado" && diferenca > Devolucao.controlado_limiteKm)
            {
                totalTemp = totalTemp * 0.10;
                total += totalTemp;
            }

            Devolucao.diferencaKm = total;
            return total;
        }

        public double CalcularConsumoTanque()
        {
            string porcentagemTanqueString = cmbTanque.Text.Split("%")[0].ToString().Trim();
            int porcentagemTanque = int.Parse(porcentagemTanqueString);
            int deduzir = 100 - porcentagemTanque;
            double divisao = (double)Decimal.Divide(deduzir, 100);
            double tanqueDeduzido = Devolucao.tanqueMaximoVeiculo * divisao;
            double valor = 0;

            if(Devolucao.tipoCombustivel == "Gasolina")
               valor = Devolucao.precoGasolina * tanqueDeduzido;

            if (Devolucao.tipoCombustivel == "Diesel")
                valor = Devolucao.precoDiesel * tanqueDeduzido;

            if (Devolucao.tipoCombustivel == "Álcool")
                valor = Devolucao.precoAlcool * tanqueDeduzido;

            Devolucao.diferencaTanque = valor;
            return valor;
        }

        public double CalcularValorDiarioPlano()
        {
            int diferenca = ObterDiferencaDias();

            double resultado = Devolucao.diario_valorDiario * diferenca;

            Devolucao.calcPlano = resultado;
            return resultado;
        }

        public double CalcularTaxasDiarias()
        {
            int dias = ObterDiferencaDias() - 1;
            double soma = 0;

            foreach (Taxa item in Devolucao.taxasDiarias)
            {
                soma += item.Valor;
            }

            Devolucao.calcTaxasDiarias = soma * dias;
            return Devolucao.calcTaxasDiarias;
        }

        private int ObterDiferencaDias()
        {
            TimeSpan intervalo = Devolucao.dataDevolvido - Devolucao.dataLocacao;

            return Convert.ToInt32(intervalo.Days);
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
            if (Devolucao.dataDevolvido < Devolucao.dataLocacao)
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
    }
   
}
