using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo;
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

        private List<GrupoVeiculo> grupos;

        private byte[] imagemSelecionada;

        private LocadoraAutomoveisDbContext dbContext;

        private IContextoPersistencia contextoPersistencia;

        public Func<Veiculo, Result<Veiculo>> GravarRegistro
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

                if (veiculo.GrupoPertencente != null)
                    cmbGrupoVeiculo.SelectedItem = veiculo.GrupoPertencente;
                else
                    cmbGrupoVeiculo.SelectedIndex = -1;

                imagemSelecionada = veiculo.Foto;
            }
        }
        public TelaCadastroVeiculo(List<GrupoVeiculo> grupos)
        {
            InitializeComponent();
            CarregarGrupos(grupos);
        }

        private void CarregarGrupos(List<GrupoVeiculo> grupos)
        {
            cmbGrupoVeiculo.Items.Clear();

            foreach (var item in grupos)
            {
                cmbGrupoVeiculo.Items.Add(item);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ImputarZeroCamposVazios();

            veiculo.GrupoPertencente = (GrupoVeiculo)cmbGrupoVeiculo.SelectedItem;

            veiculo.Modelo = txbModelo.Text;
            veiculo.Placa = txbPlaca.Text;
            veiculo.Cor = txbCor.Text;
            veiculo.Ano = Convert.ToInt32(txbAno.Text);
            veiculo.TipoCombustivel = cmbTipoCombustivel.Text;
            veiculo.CapacidadeTanque = Convert.ToInt32(txbCapacidadeTanque.Text);
            veiculo.StatusVeiculo = cmbStatus.Text;
            veiculo.QuilometragemAtual = Convert.ToInt32(txbQuilometragemAtual.Text);

            veiculo.Foto = imagemSelecionada;

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao == null)
            {
                MessageBox.Show("Tentativa de inserir 'Placa' duplicada", "Aviso");
                return;
            }

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

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
            txbCapacidadeTanque.Clear();
            txbQuilometragemAtual.Clear();
            pbFoto.Image = null;

            cmbGrupoVeiculo.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbTipoCombustivel.SelectedIndex = -1;

            txbModelo.Focus();
        }

        private void ImputarZeroCamposVazios()
        {
            if (txbAno.Text == "")
                txbAno.Text = "0";

            if (txbCapacidadeTanque.Text == "")
                txbCapacidadeTanque.Text = "0";

            if (txbQuilometragemAtual.Text == "")
                txbQuilometragemAtual.Text = "0";
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            imagemSelecionada = veiculo.Foto;

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

        public static bool ValidarCampoData(string data)
        {
            DateTime date = new();

            if (DateTime.TryParse(data, out date) == false && data.Length != 4)
                return false;

            return true;
        }

        private void TelaCadastroVeiculo_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
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
            ValidadorCampos.ImpedirCharEspeciais(e);
        }

        private void txbAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidadorAno(e);
        }

        private void TelaCadastroVeiculo_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void txbPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidadorPlacaVeiculo(e);
        }

        private void txbCor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidadorCorVeiculo(e);
        }

        private void txbAno_Leave(object sender, EventArgs e)
        {
            if (!ValidarCampoData(txbAno.Text))
                txbAno.Clear();
        }
    }
}
