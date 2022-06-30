using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System.Collections.Generic;

using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public class ControladorTaxa : ControladorBase
    {
        ServicoTaxa servicoTaxa;
        TaxaControl tabelaTaxas;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroTaxa tela = new();
            tela.Taxa = new();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            Taxa Selecionado = ObtemTaxaSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxa tela = new();

            tela.Taxa = Selecionado;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa Selecionado = ObtemTaxaSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoTaxa.Excluir(Selecionado);

                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfiguracaoStripTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxas == null)
                tabelaTaxas = new TaxaControl();

            CarregarTaxas();

            return tabelaTaxas;
        }

        private void CarregarTaxas()
        {
            List<Taxa> Taxas = servicoTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(Taxas);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {Taxas.Count} Taxa(s)");
        }

        private Taxa ObtemTaxaSelecionado()
        {
            var numero = tabelaTaxas.ObtemNumerTaxaSelecionado();

            return servicoTaxa.SelecionarPorId(numero);
        }

    }
}
