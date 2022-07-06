using FluentValidation.Results;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Condutor
{
    public partial class TelaCadastroCondutor : Form
    {
        private Condutor condutor;
        public TelaCadastroCondutor(List<Cliente> clientes)
        {
            InitializeComponent();

            CarregarClientes(clientes);
        }
        public Func<Condutor, ValidationResult> GravarRegistro
        {
            get; set;
        }
        public Condutor Condutor
        {
            get { return condutor; }
            set 
            { 
                condutor = value;

                tbNome.Text = condutor.Nome;
                tbCnh.Text = condutor.Cnh;
                tbEndereco.Text = condutor.Endereco;
                tbEmail.Text = condutor.Email;
                tbTelefone.Text = condutor.Telefone;
                tbCnh.Text = condutor.Cnh;
                tbCpf.Text = condutor.Cpf;
                txtDataVencimentoCnh.Value = condutor.VencimentoCnh;
                
                if(condutor.Cliente != null)
                    cmbClientes.SelectedItem = condutor.Cliente;
                else
                    cmbClientes.SelectedIndex = -1;
            }
        }

        private void TelaCadastroCondutor_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (var item in clientes)
            {
                cmbClientes.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            condutor.Nome = tbNome.Text;
            condutor.Cpf = tbCpf.Text;
            condutor.Telefone = tbTelefone.Text;
            condutor.Email = tbEmail.Text;
            condutor.Endereco = tbEndereco.Text;
            condutor.Cnh = tbCnh.Text;
            condutor.VencimentoCnh = txtDataVencimentoCnh.Value;

            if (condutor.Cliente != null)
                condutor.Cliente = (Cliente)cmbClientes.SelectedItem;
            else
            {
                var novoClienteVazio = new Cliente() { Nome = "" };
                condutor.Cliente = novoClienteVazio;
            }

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)cmbClientes.SelectedItem;
            if (clienteSelecionado.TipoCliente == EnumTipoCliente.PessoaFisica)
                cbClienteECondutor.Enabled = true;
            else
            {
                cbClienteECondutor.Enabled = false;
                cbClienteECondutor.Checked = false;

                tbNome.Text = "";
                tbCpf.Text = "";
                tbEmail.Text = "";
                tbEndereco.Text = "";
                tbTelefone.Text = "";
            }
        }

        private void cbClienteECondutor_CheckedChanged(object sender, EventArgs e)
        {
            CarregarDoCondutor();
        }

        private void CarregarDoCondutor()
        {
            Cliente clienteSelecionado = (Cliente)cmbClientes.SelectedItem;

            if(clienteSelecionado != null && cbClienteECondutor.Checked == false)
            {
                tbNome.Text = "";
                tbCpf.Text = "";
                tbEmail.Text = "";
                tbEndereco.Text = "";
                tbTelefone.Text = "";

                tbNome.Enabled = true;
                tbCpf.Enabled = true;
                tbTelefone.Enabled = true;
                tbEmail.Enabled = true;
                tbEndereco.Enabled = true;
            }
            else
            {

                tbNome.Text = clienteSelecionado.Nome;
                tbCpf.Text = clienteSelecionado.Cpf;
                tbEmail.Text = clienteSelecionado.Email;
                tbEndereco.Text = clienteSelecionado.Endereco;
                tbTelefone.Text = clienteSelecionado.Telefone;

                tbNome.Enabled = false;
                tbCpf.Enabled = false;
                tbTelefone.Enabled = false;
                tbEmail.Enabled = false;
                tbEndereco.Enabled = false;
                
            }
        }

        private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidarCampoEmail(e);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbCpf.Clear();
            tbCnh.Clear();
            tbNome.Text = "";
            tbEmail.Text = "";
            tbEndereco.Text = "";
            tbTelefone.Text = "";
            cbClienteECondutor.Checked = false;
            cmbClientes.SelectedIndex = -1;

            tbNome.Focus();
        }
    }
}
