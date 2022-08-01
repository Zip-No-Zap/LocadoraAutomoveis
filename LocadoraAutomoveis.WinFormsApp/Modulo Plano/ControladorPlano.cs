using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentResults;
using System;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public  class ControladorPlano : ControladorBase
    {
        ServicoPlano servicoPlano;
        PlanoControl tabelaPlanos;
        readonly ServicoGrupoVeiculo servicoGrupoVeiculo;

        public ControladorPlano(ServicoPlano servicoPlano, ServicoGrupoVeiculo servicoGrupoVeiculo)
        {
            this.servicoPlano = servicoPlano;
            this.servicoGrupoVeiculo = servicoGrupoVeiculo;
        }

        public override void Inserir()
        {
            Result<List<GrupoVeiculo>> resultadoResult = servicoGrupoVeiculo.SelecionarTodos();

            var grupos = servicoGrupoVeiculo.SelecionarTodos().Value;

            var tela = new TelaCadastroPlano(grupos);

            if (resultadoResult.IsSuccess)
            {
                tela.Plano = new();

                tela.GravarRegistro = servicoPlano.Inserir;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarPlanos();
                }
            }
        }

        public override void Editar()
        {
            var id = tabelaPlanos.ObtemNumeroPlanoSelecionado();

            var grupos = servicoGrupoVeiculo.SelecionarTodos().Value;

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                    "Edição de Plano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlano.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Plano", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var Selecionado = resultado.Value;

            TelaCadastroPlano tela = new(grupos);

            tela.Plano = Selecionado;

            tela.GravarRegistro = servicoPlano.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Excluir()
        {
            var id = tabelaPlanos.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Plano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlano.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selecionado = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano?",
            "Exclusão de Plano", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var exclusaoResult = servicoPlano.Excluir(selecionado);

                if (exclusaoResult.IsFailed)
                    MessageBox.Show("Não foi possível excluir este plano!\n\n" + exclusaoResult.Errors[0], "Aviso");

                CarregarPlanos();
            }
        }
        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfiguracaoStripPlano();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanos == null)
                tabelaPlanos = new PlanoControl();

            CarregarPlanos();

            return tabelaPlanos;
        }

        private void CarregarPlanos()
        {
            Result<List<Plano>> resultado = servicoPlano.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Plano> plano = resultado.Value;

                tabelaPlanos.AtualizarRegistros(plano);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {plano.Count} plano(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Result<Plano> ObtemPlanoSelecionado()
        {
            var numero = tabelaPlanos.ObtemNumeroPlanoSelecionado();

            return servicoPlano.SelecionarPorId(numero);
        }
    }
}
