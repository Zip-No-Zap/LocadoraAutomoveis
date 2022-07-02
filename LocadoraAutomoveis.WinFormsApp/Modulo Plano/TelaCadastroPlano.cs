using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public partial class TelaCadastroPlano : Form
    {
        private Plano plano;

        public Func<Plano, ValidationResult> GravarRegistro
        {
            get; set;
        }

        public Plano Plano
        {
            get
            {
                return plano;
            }
            set
            {
                plano = value;

                if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[0])
                {
                    tbValorDiario_Diario.Text = plano.ValorDiario.ToString();
                    tbValorKmRodado_Diario.Text = plano.ValorPorKm.ToString();
                }
                else if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[1])
                {
                    tbValorDiario_Livre.Text = plano.ValorDiario.ToString();
                }
                else if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[2])
                {
                    tbValorDiario_Controlado.Text = plano.ValorDiario.ToString();
                    tbKmRodado_Controlado.Text = plano.ValorPorKm.ToString();
                    tbLimiteQuilometragem.Text = plano.LimiteQuilometragem.ToString();
                }
            }
        }

        public TelaCadastroPlano()
        {
            InitializeComponent();
        }

        private void ObterItensGrupoVeiculo()
        {
            var servicoGrupo = new ServicoGrupoVeiculo(new LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo.RepositorioGrupoVeiculoEmBancoDados());

            var nomes = servicoGrupo.SelecionarTodos();

            foreach (GrupoVeiculo gv in nomes)
            {
                cbGrupo.Items.Add(gv.Nome);
            }
        }

         private void LimparCamposDiario()
        {
            tbValorDiario_Diario.Clear();
            tbValorKmRodado_Diario.Clear();
        }

        private void LimparCampoLivre()
        {
            tbValorDiario_Livre.Clear();
        }
        private void LimparCamposControlado()
        {
            tbValorDiario_Controlado.Clear();
            tbKmRodado_Controlado.Clear();
            tbLimiteQuilometragem.Clear();
        }

        private void TelaCadastroPlano_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");

            ObterItensGrupoVeiculo();

            VerificarPlanosCadastrados();
        }

        private void VerificarPlanosCadastrados()
        {
            bool n = false;

            while (true)
            {
                if (tbValorDiario_Livre.Text != "0" && tbValorKmRodado_Diario.Text != "0")
                    n = true;

                if (tbValorDiario_Livre.Text != "0")
                    n = true;

                if (tbValorDiario_Controlado.Text != "0" && tbKmRodado_Controlado.Text != "0" && tbLimiteQuilometragem.Text != "0")
                    n = true;

                if (n)
                {
                    btnOK.Enabled = true;
                    break;
                }
            }
        }

        private void TelaCadastroPlano_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[0])
            {
                LimparCamposDiario();
            }
            else if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[1])
            {
                LimparCampoLivre();
            }
            else

                LimparCamposControlado();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[0])
            {
                plano.ValorDiario = float.Parse(tbValorDiario_Diario.Text);
                plano.ValorPorKm = float.Parse(tbValorKmRodado_Diario.Text);
                plano.Descricao = "Diário";
            }
            else if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[1])
            {
                plano.ValorDiario = float.Parse(tbValorDiario_Livre.Text);
                plano.Descricao = "Livre";
            }
            else if (tabControlPlano.SelectedTab == tabControlPlano.TabPages[2])
            {
                plano.ValorDiario = float.Parse(tbValorDiario_Controlado.Text);
                plano.ValorPorKm = float.Parse(tbKmRodado_Controlado.Text);
                plano.LimiteQuilometragem = Convert.ToInt32(tbLimiteQuilometragem.Text);
                plano.Descricao = "Controlado";
            }

            ValidationResult resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void tbValorDiario_Diario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbValorKmRodado_Diario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbValorDiario_Livre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbValorDiario_Controlado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbKmRodado_Controlado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbLimiteQuilometragem_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }
    }
}
