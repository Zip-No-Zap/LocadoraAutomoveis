using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public  class ControladorPlano : ControladorBase
    {
        ServicoPlano servicoPlano;
        PlanoControl tabelaPlanos;

        public ControladorPlano(ServicoPlano servicoPlano)
        {
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            TelaCadastroPlano tela = new()
            {
                Plano = new()
                {
                    Grupo = new(null)
                },
                
                GravarRegistro = servicoPlano.Inserir
            };


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Editar()
        {
            var id = tabelaPlanos.ObtemNumeroPlanoSelecionado();

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

            TelaCadastroPlano tela = new();

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

            var Selecionado = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir o plano?",
            "Exclusão de Plano", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                servicoPlano.Excluir(Selecionado);
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
