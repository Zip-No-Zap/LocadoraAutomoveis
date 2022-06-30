using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa;
using System.Collections.Generic;

using System.Windows.Forms;

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

          //  tela.GravarRegistro = repoTaxa.Inserir;

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

         //   tela.GravarRegistro = repoTaxa.Editar;

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
                repoTaxa.Excluir(Selecionado);

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
