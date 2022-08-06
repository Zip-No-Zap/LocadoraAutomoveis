using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.Aplicacao.Modulo_Taxa;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentResults;
using System.Linq;
using System;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        readonly ServicoLocacao servicoLocacao;
        readonly ServicoCondutor servicoCondutor;
        readonly ServicoVeiculo servicoVeiculo;
        readonly ServicoTaxa servicoTaxa;
        readonly ServicoCliente servicoCliente;
        readonly ServicoGrupoVeiculo servicoGrupo;
        readonly ServicoPlano servicoPlano;
        LocacaoControl tabelaLocacoes;

        public ControladorLocacao()
        {

        }

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCondutor servicoCondutor,
            ServicoVeiculo servicoVeiculo, ServicoTaxa servicoTaxa, ServicoCliente servicoCliente, ServicoGrupoVeiculo servicoGrupo, ServicoPlano servicoPlano)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCondutor = servicoCondutor;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoTaxa = servicoTaxa;
            this.servicoCliente = servicoCliente;
            this.servicoGrupo = servicoGrupo;
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            Result<List<Locacao>> resultadoResult = servicoLocacao.SelecionarTodos();

            var clientes = servicoCliente.SelecionarTodos().Value;
            var condutores = servicoCondutor.SelecionarTodos().Value;
            var veiculos = servicoVeiculo.SelecionarTodos().Value;
            var taxas = servicoTaxa.SelecionarTodos().Value;
            var grupos = servicoGrupo.SelecionarTodos().Value;
            var planos = servicoPlano.SelecionarTodos().Value;
            var locacoes = servicoLocacao.SelecionarTodos().Value;

            var tela = new TelaCadastroLocacao(clientes, condutores, veiculos, taxas, grupos, planos, locacoes, false);

            if (resultadoResult.IsSuccess)
            {
                tela.Locacao = new();

                tela.Locacao._estaLocado = "sim";

                tela.GravarRegistro = servicoLocacao.Inserir;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    tela.GerarPdf();
                    CarregarLocacoes();
                }
            }
        }

        public override void Editar()
        {
            var id = tabelaLocacoes.ObtemNumeroLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selecionado = resultado.Value;

            var condutores = servicoCondutor.SelecionarTodos().Value;
            var veiculos = servicoVeiculo.SelecionarTodos().Value;
            var taxas = servicoTaxa.SelecionarTodos().Value;
            var clientes = servicoCliente.SelecionarTodos().Value;
            var grupos = servicoGrupo.SelecionarTodos().Value;
            var planos = servicoPlano.SelecionarTodos().Value;
            var locacoes = servicoLocacao.SelecionarTodos().Value;

            TelaCadastroLocacao tela = new(clientes, condutores, veiculos, taxas, grupos, planos, locacoes, false);

            tela.Locacao = selecionado;

            tela.Locacao._estaLocado = "sim";

            if (tela.Locacao.Status == "Fechada")
            {
                MessageBox.Show("Não é possível editar uma locação em situação: 'Fechada'", "Aviso");
                return;
            }

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                tela.GerarPdf();
                CarregarLocacoes();
            }
        }

        public override void Excluir()
        {
            var id = tabelaLocacoes.ObtemNumeroLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selecionado = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?",
            "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(selecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();

                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Locação",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void ExcluirFechadas()
        {
            if (MessageBox.Show("As locações em situação 'Fechada' serão arquivadas PDF e excluídas da tabela.\n\n" +
               "Deseja realmente arquivar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var resultado = servicoLocacao.SelecionarTodos();

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message,
                        "Exclusão de Locações 'Fechadas'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selecionadas = resultado.Value;

                var fechadas = selecionadas.FindAll(x => x.Status == "Fechada");

                var resultadoExclusao = servicoLocacao.ExcluirFechadas(fechadas);

                TelaCadastroLocacao tela = new();

                if (resultadoExclusao.IsSuccess)
                {
                    tela.pdFechadas = true;
                    tela.GerarPdf();
                    CarregarLocacoes();
                }
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Locações 'Fechadas'",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void FazerDevolucao()
        {
            var id = tabelaLocacoes.ObtemNumeroLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                "Devolução de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Devolução de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selecionado = resultado.Value;

            var condutores = servicoCondutor.SelecionarTodos().Value;
            var veiculos = servicoVeiculo.SelecionarTodos().Value;
            var taxas = servicoTaxa.SelecionarTodos().Value;
            var clientes = servicoCliente.SelecionarTodos().Value;
            var grupos = servicoGrupo.SelecionarTodos().Value;
            var planos = servicoPlano.SelecionarTodos().Value;
            var locacoes = servicoLocacao.SelecionarTodos().Value;

            TelaCadastroLocacao tela = new(clientes, condutores, veiculos, taxas, grupos, planos, locacoes, true);

            tela.Locacao = selecionado;

            if (tela.Locacao.Status == "Fechada")
            {
                MessageBox.Show("Não é possível fazer devolução de uma locação em situação: 'Fechada'", "Aviso");
                return;
            }

            tela.GravarRegistro = servicoLocacao.Editar;


            if (tela.ShowDialog() == DialogResult.OK)
            {
                tela.GerarPdf();
                CarregarLocacoes();
            }
        }

        public override void Separar()
        {
            ObtemListagemAgrupada();
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaLocacoes == null)
                tabelaLocacoes = new LocacaoControl();

            CarregarLocacoes();

            return tabelaLocacoes;
        }

        public UserControl ObtemListagemAgrupada()
        {
            if (tabelaLocacoes == null)
                tabelaLocacoes = new LocacaoControl();

            CarregarLocacoesAgrupadas();

            return tabelaLocacoes;
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacoes.AtualizarRegistros(locacoes);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} Locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarLocacoesAgrupadas()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                var agrupadas = locacoes
                    .OrderBy(x => x.Status)
                    .Select(x => x)
                    .ToList();

                tabelaLocacoes.AtualizarRegistros(agrupadas);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} Locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
