using FluentResults;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
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

        public TelaCadastroLocacao(List<Condutor> condutores, List<Veiculo> veiculos, List<Taxa> itensAdicionais)
        {
            InitializeComponent();
            CarregarCondutores(condutores);
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

        private void CarregarCondutores(List<Condutor> condutores)
        {
            cbCondutor_Cliente.Items.Clear();

            foreach (var item in condutores)
            {
                cbCondutor_Cliente.Items.Add(item);
            }
        }
    }
}
