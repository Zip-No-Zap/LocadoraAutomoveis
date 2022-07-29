


using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        readonly ServicoLocacao servicoLocacao;
        readonly ServicoCondutor servicoCondutor;
        LocacaoControl tabelaLocacaos;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCondutor servicoCondutor)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            Result<List<Condutor>> resultadoResult = servicoCondutor.SelecionarTodos();

            var condutores = servicoCondutor.SelecionarTodos().Value;

            var tela = new TelaCadastroLocacao(condutores, null, null);

            if (resultadoResult.IsSuccess)
            {
                tela.Locacao = new();

                tela.GravarRegistro = servicoLocacao.Inserir;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarLocacoes();
                }
            }

            //TODO : criar o inserir e editar do controlador locacao

            //tela.GravarRegistro = servicoLocacao.Inserir;

            //if (tela.ShowDialog() == DialogResult.OK)
            //{
            //    CarregarLocacoes();
            //}
        }

        public override void Editar()
        {
            var id = tabelaLocacaos.ObtemNumeroLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;

            TelaCadastroLocacao tela = new(null, null, null, null);

            tela.Locacao = Selecionado;

            tela.GravarRegistro = servicoLocacao.Editar;


            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarLocacoes();
            }
        }

        public override void Excluir()
        {
            var id = tabelaLocacaos.ObtemNumeroLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir o veiculo?",
            "Exclusão de Locacao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(Selecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();

                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Locacao",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaLocacaos == null)
                tabelaLocacaos = new LocacaoControl();

            CarregarLocacoes();

            return tabelaLocacaos;
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> veiculos = resultado.Value;

                tabelaLocacaos.AtualizarRegistros(veiculos);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} Locacao(s)");
            }

            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
