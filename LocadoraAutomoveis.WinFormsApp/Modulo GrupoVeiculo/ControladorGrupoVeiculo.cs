using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo
{
    public class ControladorGrupoVeiculo : ControladorBase
    {
        readonly ServicoGrupoVeiculo servicoFuncionario;
        GrupoVeiculoControl tabelaGrupoVeiculo;

        public ControladorGrupoVeiculo(ServicoGrupoVeiculo servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoVeiculo tela = new();
            tela.GrupoVeiculo = new();

           // tela.GravarRegistro = repoGrupoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGruposVeiculos();
            }
        }



        public override void Editar()
        {
            GrupoVeiculo Selecionado = ObtemGrupoVeiculoSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um Grupo primeiro",
                "Edição de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoVeiculo tela = new();

            tela.GrupoVeiculo = Selecionado;

           // tela.GravarRegistro = repoGrupoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGruposVeiculos();
            }
        }



        public override void Excluir()
        {
            GrupoVeiculo Selecionado = ObtemGrupoVeiculoSelecionado();


            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um Grupo primeiro",
                "Exclusão de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Grupo?",
                "Exclusão de Grupo Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoFuncionario.Excluir(Selecionado);

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
            List<GrupoVeiculo> grupos = servicoFuncionario.SelecionarTodos();

            tabelaGrupoVeiculo.AtualizarRegistros(grupos);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de Veiculo(s)");
        }

        private GrupoVeiculo ObtemGrupoVeiculoSelecionado()
        {
            var numero = tabelaGrupoVeiculo.ObtemNumeroGrupoVeiculoSelecionado();

            return servicoFuncionario.SelecionarPorId(numero);
        }
    }
}
