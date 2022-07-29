using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo
{
    public class ControladorGrupoVeiculo : ControladorBase
    {
        readonly ServicoGrupoVeiculo servicoGrupoVeiculo;
        GrupoVeiculoControl tabelaGrupoVeiculo;

        public ControladorGrupoVeiculo(ServicoGrupoVeiculo servicoGrupoVeiculo)
        {
            this.servicoGrupoVeiculo = servicoGrupoVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoVeiculo tela = new();

            tela.GrupoVeiculo = new(null);

            tela.GravarRegistro = servicoGrupoVeiculo.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarGruposVeiculos();
            }
        }

        public override void Editar()
        {
            var id = tabelaGrupoVeiculo.ObtemNumeroGrupoVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                    "Edição de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                var selecionado = resultado.Value;

                TelaCadastroGrupoVeiculo tela = new();

                tela.GrupoVeiculo = selecionado;

                tela.GravarRegistro = servicoGrupoVeiculo.Editar;


                if (tela.ShowDialog() == DialogResult.OK)

                    CarregarGruposVeiculos();
        }

        public override void Excluir()
        {
            var id = tabelaGrupoVeiculo.ObtemNumeroGrupoVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo primeiro",
                "Exclusão de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoGrupoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir o grupo?",
            "Exclusão de Grupo Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var exclusaoResult = servicoGrupoVeiculo.Excluir(Selecionado);

                if (exclusaoResult.IsFailed)
                    MessageBox.Show("Não foi possível excluir este grupo!\n\n" + exclusaoResult.Errors[0], "Aviso");

                CarregarGruposVeiculos();
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoVeiculo == null)
                tabelaGrupoVeiculo = new GrupoVeiculoControl();

            CarregarGruposVeiculos();

            return tabelaGrupoVeiculo;
        }

        private void CarregarGruposVeiculos()
        {
            var resultado = servicoGrupoVeiculo.SelecionarTodos();
          

            if (resultado.IsSuccess)
            {
                List<GrupoVeiculo> grupos = resultado.Value;

                tabelaGrupoVeiculo.AtualizarRegistros(grupos);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de Veiculo(s)");
            }

            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupo Veiculo"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
