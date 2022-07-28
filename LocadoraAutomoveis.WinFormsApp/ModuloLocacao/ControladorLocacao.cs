


using LocadoraAutomoveis.Aplicacao.ModuloLocacao;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        readonly ServicoLocacao servicoLocacao;
        //readonly ServicoGrupoLocacao servicoGrupoLocacao;
        LocacaoControl tabelaLocacaos;

        public ControladorLocacao(ServicoLocacao servicoLocacao) //ServicoGrupoLocacao servicoGrupoLocacao)
        {
            this.servicoLocacao = servicoLocacao;
            //this.servicoGrupoLocacao = servicoGrupoLocacao;
        }

        public override void Inserir()
        {
            //TODO : criar o inserir e editar do controlador locacao

            //tela.GravarRegistro = servicoLocacao.Inserir;

            //if (tela.ShowDialog() == DialogResult.OK)
            //{
            //    CarregarLocacaos();
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
                CarregarLocacaos();
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
                    CarregarLocacaos();

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

            CarregarLocacaos();

            return tabelaLocacaos;
        }

        private void CarregarLocacaos()
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
