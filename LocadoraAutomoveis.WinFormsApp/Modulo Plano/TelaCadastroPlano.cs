using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentResults;
using System;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public partial class TelaCadastroPlano : Form
    {
        private Plano plano;

        public Func<Plano, Result<Plano>> GravarRegistro
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

                tbValorDiario_Diario.Text = plano.ValorDiario_Diario.ToString("N2");
                tbValorKmRodado_Diario.Text = plano.ValorPorKm_Diario.ToString("N2");

                tbValorDiario_Livre.Text = plano.ValorDiario_Livre.ToString("N2");

                tbValorDiario_Controlado.Text = plano.ValorDiario_Controlado.ToString("N2");
                tbKmRodado_Controlado.Text = plano.ValorPorKm_Controlado.ToString("N2");
                tbLimiteQuilometragem.Text = plano.LimiteQuilometragem_Controlado.ToString("N2");
            }
        }

        public TelaCadastroPlano(List<GrupoVeiculo> grupos)
        {
            InitializeComponent();

            CarregarGrupos(grupos);
        }

        private void CarregarGrupos(List<GrupoVeiculo> grupos)
        {
            cbGrupo.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupo.Items.Add(item);
            }
        }

        //private void ObterItensGrupoVeiculo()
        //{
        //    var servicoGrupo = new ServicoGrupoVeiculo(new LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo.RepositorioGrupoVeiculoEmBancoDados());

        //    var nomesResult = servicoGrupo.SelecionarTodos();

        //    List<GrupoVeiculo> nomes = null;

        //    if (nomesResult.IsSuccess)
        //        nomes = nomesResult.Value;

        //    if (nomes.Count != 0)
        //    {
        //        foreach (GrupoVeiculo gv in nomes)
        //        {
        //            cbGrupo.Items.Add(gv.Nome);
        //        }
        //    }
        //}

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

            plano.Grupo = (GrupoVeiculo)cbGrupo.SelectedItem;

            plano.ValorDiario_Diario = float.Parse(tbValorDiario_Diario.Text);
            plano.ValorPorKm_Diario = float.Parse(tbValorKmRodado_Diario.Text);

            plano.ValorDiario_Livre = float.Parse(tbValorDiario_Livre.Text);

            plano.ValorDiario_Controlado = float.Parse(tbValorDiario_Controlado.Text);
            plano.ValorPorKm_Controlado = float.Parse(tbKmRodado_Controlado.Text);
            plano.LimiteQuilometragem_Controlado = Convert.ToInt32(tbLimiteQuilometragem.Text);
        
            Result <Plano> resultadoValidacao = GravarRegistro(plano);
           
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

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
    }
}
