using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator;
using LocadoraAutomoveis.WinFormsApp.Modulo_Cliente;
using LocadoraAutomoveis.WinFormsApp.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao;
using LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Modulo_Taxa;
using LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp
{
    public partial class FormPrincipal : Form
    {
        private ControladorBase controlador;
        private IServiceLocator serviceLocator;

        public FormPrincipal(IServiceLocator serviceLocator)
        {
            InitializeComponent();

            Instancia = this;

            toolStripPrincipal.Text = string.Empty;
            lblToolStripPrincipal.Text = string.Empty;

            this.serviceLocator = serviceLocator;
        }

        public static FormPrincipal Instancia
        {
            get;
            private set;
        }

        private void HabilitarBotoesToolStrip()
        {
            btnInserir.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void ConfigurarTelaPrincipal(ControladorBase control)
        {
            controlador = control;

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());
            HabilitarBotoesToolStrip();
        }

        private void taxaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
            HabilitarBotoesToolStrip();
        }

        private void grupoDeVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoVeiculo>());
            HabilitarBotoesToolStrip();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
            HabilitarBotoesToolStrip();
        }

        private void condutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutor>());
            HabilitarBotoesToolStrip();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculo>());
            HabilitarBotoesToolStrip();
        }

        private void planoDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlano>());
            HabilitarBotoesToolStrip();
        }

        private void combustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoControl configuracaoTela = new ConfiguracaoControl();

            panelPrincipal.Controls.Add(configuracaoTela);
        }
    }
}
