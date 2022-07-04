using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private Veiculo veiculo;

        private byte[] imagemSelecionada;

        public Func<Veiculo, ValidationResult> GravarRegistro
        {
            get; set;
        }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;

                txbModelo.Text = veiculo.Modelo;
                txbPlaca.Text = veiculo.Placa;
                txbCor.Text = veiculo.Cor;
                txbAno.Text = veiculo.Ano.ToString();
                cmbTipoCombustivel.Text = veiculo.TipoCombustivel;
                txbCapacidadeTanque.Text = veiculo.CapacidadeTanque.ToString();
                cmbStatus.Text = veiculo.StatusVeiculo;
                txbQuilometragemAtual.Text = veiculo.QuilometragemAtual.ToString();
                pbFoto.Image = veiculo.Imagem;
            }
        }
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
           // CarregarGrupos(grupos);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbGrupoVeiculo.Text))
                veiculo.GrupoPertencente.Id = int.Parse(lblIDGrupo.Text);

            veiculo.GrupoPertencente.Nome = cmbGrupoVeiculo.Text;

            veiculo.Modelo = txbModelo.Text;
            veiculo.Placa = txbPlaca.Text;
            veiculo.Cor = txbCor.Text;
            veiculo.Ano = Convert.ToInt32(txbAno.Text);
            veiculo.TipoCombustivel = cmbTipoCombustivel.Text;
            veiculo.CapacidadeTanque = Convert.ToInt32(txbCapacidadeTanque.Text);
            veiculo.StatusVeiculo = cmbStatus.Text;
            veiculo.QuilometragemAtual = Convert.ToInt32(txbQuilometragemAtual.Text);
            veiculo.Foto = imagemSelecionada;

            ValidationResult resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao == null)
            {
                MessageBox.Show("Tentativa de inserir 'Placa' duplicada", "Aviso");
                return;
            }

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbModelo.Clear();
            txbPlaca.Clear();
            txbCor.Clear();
            txbAno.Clear();
            cmbGrupoVeiculo.Items.Clear();
            txbCapacidadeTanque.Clear();
            cmbGrupoVeiculo.Items.Clear();
            cmbStatus.Items.Clear();
            txbQuilometragemAtual.Clear();
            pbFoto.Image = null;
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagemSelecionada = File.ReadAllBytes(openFileDialog1.FileName);

                using (var ms = new MemoryStream(imagemSelecionada))
                    pbFoto.Image = new Bitmap(ms);
            }
        }

        private void TelaCadastroVeiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void CarregarGrupos(List<GrupoVeiculo> grupos)
        {
            cmbGrupoVeiculo.Items.Clear();

            foreach (var item in grupos)
            {
                cmbGrupoVeiculo.Items.Add(item);
            }
        }

        private void TelaCadastroVeiculo_Load(object sender, EventArgs e)
        {
            ObterItensGrupoVeiculo();
        }

        private void ObterIdGrupoVeiculoj()
        {
            if (cmbGrupoVeiculo.SelectedIndex != -1)
            {
                var servicoGrupo = new ServicoGrupoVeiculo(new LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo.RepositorioGrupoVeiculoEmBancoDados());
                var grupos = servicoGrupo.SelecionarTodos();

                var grupoEncontrado = grupos.Find(g => g.Nome.Equals(cmbGrupoVeiculo.SelectedItem.ToString()));

                lblIDGrupo.Text = grupoEncontrado.Id.ToString();
            }
        }

        private void cmbGrupoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObterIdGrupoVeiculoj();
        }

        private void ObterItensGrupoVeiculo()//TODO : Obter itens grupo dever ser feito pelo controlador
        {
            var servicoGrupo = new ServicoGrupoVeiculo(new LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo.RepositorioGrupoVeiculoEmBancoDados());

            var nomes = servicoGrupo.SelecionarTodos();

            foreach (GrupoVeiculo gv in nomes)
            {
                cmbGrupoVeiculo.Items.Add(gv.Nome);
            }
        }

        private void txbAno_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txbModelo_Leave(object sender, EventArgs e)
        {
            ValidadorCampos.ImpedirTextoMenorDois(txbModelo.Text);
        }

        private void txbCapacidadeTanque_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbQuilometragemAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.PermitirApenasLetrasNumero(e);
        }

        private void txbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbCor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
