using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
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
                MessageBox.Show("Selecione um grupo primeiro",
                "Edição de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoVeiculo tela = new();

            tela.GrupoVeiculo = Selecionado;

            tela.GravarRegistro = servicoGrupoVeiculo.Editar;

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
                MessageBox.Show("Selecione um grupo primeiro",
                "Exclusão de Grupo Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo?",
                "Exclusão de Grupo Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoGrupoVeiculo.Excluir(Selecionado);

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
            List<GrupoVeiculo> grupos = servicoGrupoVeiculo.SelecionarTodos();

            tabelaGrupoVeiculo.AtualizarRegistros(grupos);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de Veiculo(s)");
        }

        private GrupoVeiculo ObtemGrupoVeiculoSelecionado()
        {
            var numero = tabelaGrupoVeiculo.ObtemNumeroGrupoVeiculoSelecionado();

            return servicoGrupoVeiculo.SelecionarPorId(numero);
        }
    }
}
