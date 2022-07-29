using FluentResults;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        private Locacao locacao;

        public TelaCadastroLocacao(List<Condutor> condutores, List<Veiculo> veiculos, List<Taxa> taxas, List<GrupoVeiculo> grupos)
        {
            InitializeComponent();
            CarregarCondutores(condutores);
            CarregarVeiculos(veiculos);
            CarregarTaxas(taxas);
            CarregarGrupos(grupos);
        }

        public Func< Locacao, Result<Locacao> > GravarRegistro
        {
            get; set;
        }

        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                cbCondutor_Cliente.SelectedItem = locacao.CondutorLocacao.Cliente == null ? cbCondutor_Cliente.SelectedIndex = -1 : locacao.CondutorLocacao.Cliente;
                cbVeiculo.SelectedItem = locacao.VeiculoLocacao == null ? cbVeiculo.SelectedIndex = -1 : locacao.VeiculoLocacao;
                cbItens.SelectedItem = locacao.ItensTaxa == null ? cbItens.SelectedIndex = -1 : locacao.ItensTaxa;

                switch (locacao.PlanoLocacao_Descricao)
                {
                    case "Diário":
                        rdDiario.Checked = true;
                        rdLivre.Checked = false;
                        rdControlado.Checked = false;
                        break;

                    case "Livre":
                        rdLivre.Checked = true;
                        rdDiario.Checked = false;
                        rdControlado.Checked = false;
                        break;

                    case "Controlado":
                        rdControlado.Checked = true;
                        rdDiario.Checked = false;
                        rdLivre.Checked = false;
                        break;
                }

                CarregarItensAdicionais(Locacao.ItensTaxa);

                    //tbNome.Text = condutor.Nome;
                    //tbCnh.Text = condutor.Cnh;
                    //tbEndereco.Text = condutor.Endereco;
                    //tbEmail.Text = condutor.Email;
                    //tbTelefone.Text = condutor.Telefone;
                    //tbCnh.Text = condutor.Cnh;
                    //tbCpf.Text = condutor.Cpf;
                    //txtDataVencimentoCnh.Value = condutor.VencimentoCnh;

                    //if (condutor.Cliente != null)
                    //    cmbClientes.SelectedItem = condutor.Cliente;
                    //else
                    //    cmbClientes.SelectedIndex = -1;
            }
        }

        private void TelaCadastroLocacao_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //condutor.Nome = tbNome.Text;
            //condutor.Cpf = tbCpf.Text;
            //condutor.Telefone = tbTelefone.Text;
            //condutor.Email = tbEmail.Text;
            //condutor.Endereco = tbEndereco.Text;
            //condutor.Cnh = tbCnh.Text;
            //condutor.VencimentoCnh = txtDataVencimentoCnh.Value;
            //condutor.Cliente = (Cliente)cmbClientes.SelectedItem;

            //if (condutor.Cliente == null)
            //{
            //    var novoClienteVazio = new Cliente() { Nome = "" };
            //    condutor.Cliente = novoClienteVazio;
            //}

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarItensAdicionais(List<Taxa> taxas)
        {
            listItens.Items.Clear();

            foreach (var item in taxas)
            {
                listItens.Items.Add(item.Descricao + " - " + item.Valor + " - " + item.Tipo);
            }
        }

        private void CarregarCondutores(List<Condutor> condutores)
        {
            cbCondutor_Cliente.Items.Clear();

            foreach (var item in condutores)
            {
                cbCondutor_Cliente.Items.Add(item);
            }
        }

        private void CarregarVeiculos(List<Veiculo> veiculos)
        {
            cbVeiculo.Items.Clear();

            foreach (var item in veiculos)
            {
                cbVeiculo.Items.Add(item);
            }
        }

        private void CarregarTaxas(List<Taxa> taxas)
        {
            cbItens.Items.Clear();

            foreach (var item in taxas)
            {
                cbItens.Items.Add(item);
            }
        }

        private void CarregarGrupos(List<Taxa> grupos)
        {
            cbGrupo.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupo.Items.Add(item);
            }
        }
    }
}
