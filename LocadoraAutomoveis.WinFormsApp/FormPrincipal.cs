using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp
{
    public partial class FormPrincipal : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;

        public FormPrincipal()
        {
            InitializeComponent();

            Instancia = this;

            toolStripPrincipal.Text = string.Empty;
            lblToolStripPrincipal.Text = string.Empty;

            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Funcionário", new ControladorFuncionario());
        }

        public static FormPrincipal Instancia
        {
            get;
            private set;
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
            HabilitarBotoesToolStrip();
        }

        private void HabilitarBotoesToolStrip()
        {
            btnInserir.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolStripBase configuracao = controlador.ObtemConfiguracaoToolStrip();

            if (configuracao != null)
            {
                toolStripPrincipal.Enabled = true;

                lblToolStripPrincipal.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarBotoes(ConfiguracaoToolStripBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolStripBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarListagem()
        {
            try
            {
                AtualizarRodape("");

                var listagemControl = controlador.ObtemListagem();

                panelPrincipal.Controls.Clear();

                listagemControl.Dock = DockStyle.Fill;

                panelPrincipal.Controls.Add(listagemControl);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Erro durante redimensionamento de coluna de preenchimento automático", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AtualizarRodape(string mensagem)
        {
            lblStatusPrincipal.Text = mensagem;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }
    }
}
