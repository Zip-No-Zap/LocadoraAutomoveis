using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        readonly ServicoVeiculo servicoVeiculo;
        readonly ServicoGrupoVeiculo servicoGrupoVeiculo;
        VeiculoControl tabelaVeiculos;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculo servicoGrupoVeiculo)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculo = servicoGrupoVeiculo;
        }

        public override void Inserir()
        {
            var grupos = servicoGrupoVeiculo.SelecionarTodos().Value;

            var tela = new TelaCadastroVeiculo(grupos);

            tela.Veiculo = new();

            tela.GravarRegistro = servicoVeiculo.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            var grupos = servicoGrupoVeiculo.SelecionarTodos().Value;


            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;

            TelaCadastroVeiculo tela = new(grupos);

            tela.Veiculo = Selecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;


            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }


        public override void Excluir()
        {
            var id = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                    "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var Selecionado = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir o veiculo?",
            "Exclusão de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(Selecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();

                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Veiculo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaVeiculos == null)
                tabelaVeiculos = new VeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculos;
        }

        private void CarregarVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                tabelaVeiculos.AtualizarRegistros(veiculos);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} Veiculo(s)");
            }

            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}




