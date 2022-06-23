using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public class ControladorTaxa : ControladorBase
    {
        RepositorioTaxaEmBancoDados repoTaxa;
        TaxaControl tabelaTaxas;

        public ControladorTaxa()
        {
            repoTaxa = new();
        }

        public override void Inserir()
        {
            TelaCadastroTaxa tela = new();
            tela.Taxa = new();

            tela.GravarRegistro = repoTaxa.Inserir;

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
                MessageBox.Show("Selecione um Taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxa tela = new();

            tela.Taxa = Selecionado;

            tela.GravarRegistro = repoTaxa.Editar;

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
                MessageBox.Show("Selecione um Taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Taxa?",
                "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repoTaxa.Excluir(Selecionado);

                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripTaxa();
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
            List<Taxa> Taxas = repoTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(Taxas);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {Taxas.Count} Taxa(s)");
        }

        private Taxa ObtemTaxaSelecionado()
        {
            var numero = tabelaTaxas.ObtemNumerTaxaSelecionado();

            return repoTaxa.SelecionarPorId(numero);
        }

    }
}
