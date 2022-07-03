using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
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
            var grupos = servicoGrupoVeiculo.SelecionarTodos();

            TelaCadastroVeiculo tela = new(grupos)
            {
                Veiculo = new(),
                GravarRegistro = servicoVeiculo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            Veiculo Selecionado = ObtemVeiculoSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um Veiculo primeiro",
                "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupos = servicoGrupoVeiculo.SelecionarTodos();

            TelaCadastroVeiculo tela = new(grupos);

            tela.Veiculo = Selecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Excluir()
        {
            Veiculo Selecionado = ObtemVeiculoSelecionado();


            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um Veiculo primeiro",
                "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Veiculo?",
                "Exclusão de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoVeiculo.Excluir(Selecionado);

                CarregarVeiculos();
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
            List<Veiculo> veiculos = servicoVeiculo.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} Veiculo(s)");
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            var numero = tabelaVeiculos.ObtemNumeroVeiculoSelecionado();

            return servicoVeiculo.SelecionarPorId(numero);
        }
    }
}
