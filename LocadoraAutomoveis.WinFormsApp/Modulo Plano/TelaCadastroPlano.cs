using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
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

                tbValorDiario_Diario.Text = plano.ValorDiario_Diario.ToString();
                tbValorKmRodado_Diario.Text = plano.ValorPorKm_Diario.ToString();

                tbValorDiario_Livre.Text = plano.ValorDiario_Livre.ToString();

                tbValorDiario_Controlado.Text = plano.ValorDiario_Controlado.ToString();
                tbKmRodado_Controlado.Text = plano.ValorPorKm_Controlado.ToString();
                tbLimiteQuilometragem.Text = plano.LimiteQuilometragem_Controlado.ToString();
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
        }

        private void TelaCadastroPlano_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimparCamposDiario();

            LimparCampoLivre();

            LimparCamposControlado();

            cbGrupo.SelectedIndex = - 1;

            tbValorDiario_Diario.Focus();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            ImputarZeroCamposVazios();

            if(!string.IsNullOrEmpty(cbGrupo.Text))
                plano.Grupo.Id = int.Parse(lblIDGrupo.Text);

            plano.Grupo.Nome = cbGrupo.Text; 

            plano.ValorDiario_Diario = float.Parse(tbValorDiario_Diario.Text);
            plano.ValorPorKm_Diario = float.Parse(tbValorKmRodado_Diario.Text);

            plano.ValorDiario_Livre = float.Parse(tbValorDiario_Livre.Text);

            plano.ValorDiario_Controlado = float.Parse(tbValorDiario_Controlado.Text);
            plano.ValorPorKm_Controlado = float.Parse(tbKmRodado_Controlado.Text);
            plano.LimiteQuilometragem_Controlado = Convert.ToInt32(tbLimiteQuilometragem.Text);
        
            ValidationResult resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void ImputarZeroCamposVazios()
        {
            if (tbKmRodado_Controlado.Text == "")
                tbKmRodado_Controlado.Text = "0";

            if (tbValorDiario_Controlado.Text == "")
                tbValorDiario_Controlado.Text = "0";

            if (tbLimiteQuilometragem.Text == "")
                tbLimiteQuilometragem.Text = "0";

            if (tbValorDiario_Livre.Text == "")
                tbValorDiario_Livre.Text = "0";

            if (tbValorKmRodado_Diario.Text == "")
                tbValorKmRodado_Diario.Text = "0";

            if (tbValorDiario_Diario.Text == "")
                tbValorDiario_Diario.Text = "0";
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

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObterIdGrupoVeiculoj();
        }

        private void ObterIdGrupoVeiculoj()
        {
            if (cbGrupo.SelectedIndex != -1) 
            {
                var servicoGrupo = new ServicoGrupoVeiculo(new LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo.RepositorioGrupoVeiculoEmBancoDados());
                var grupos = servicoGrupo.SelecionarTodos();

                var grupoEncontrado = grupos.Find(g => g.Nome.Equals(cbGrupo.SelectedItem.ToString()));

                lblIDGrupo.Text = grupoEncontrado.Id.ToString();
            }
        }
    }
}
