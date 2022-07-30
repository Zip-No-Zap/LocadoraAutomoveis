using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System;
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
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;

            TelaCadastroTaxa tela = new();

            tela.Taxa = Selecionado;

            tela.GravarRegistro = servicoTaxa.Editar;


            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarTaxas();
            }
            
        }

        public override void Excluir()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?",
            "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var exclusaoResult = servicoTaxa.Excluir(Selecionado);

                if (exclusaoResult.IsFailed)
                    MessageBox.Show("Não foi possível excluir esta taxa!\n\n" + exclusaoResult.Errors[0], "Aviso");

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
            Result<List<Taxa>> resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> plano = resultado.Value;

                tabelaTaxas.AtualizarRegistros(plano);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {plano.Count} taxa(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private Result<Taxa> ObtemTaxaSelecionado()
        {
            var numero = tabelaTaxas.ObtemNumeroTaxaSelecionado();

            return servicoTaxa.SelecionarPorId(numero);
        }

    }
}
