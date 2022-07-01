using FluentValidation.Results;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Cliente
{
    public partial class TelaCadastroCliente : Form
    {
        private Cliente cliente;

        public Func<Cliente, ValidationResult> GravarRegistro
        {
            get; set;
        }
        public TelaCadastroCliente()
        {
            InitializeComponent();
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;

                tbNome.Text = cliente.Nome;
                tbEndereco.Text = cliente.Endereco;
                tbEmail.Text = cliente.Email;
                tbTelefone.Text = cliente.Telefone;

                if (cliente.TipoCliente == EnumTipoCliente.PessoaFisica)
                {
                    rdbPessoaFisica.Checked = true;
                    tbCPF.Text = cliente.Cpf;
                    
                }
                else
                {
                    rdbPessoaJuridica.Checked = true;
                    tbCNPJ.Text = cliente.Cnpj;
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbCNPJ.Clear();
            tbCPF.Clear();
            tbEmail.Clear();
            tbEndereco.Clear();
            tbTelefone.Clear();
            rdbPessoaFisica.Checked = false;
            rdbPessoaJuridica.Checked = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cliente.Nome = tbNome.Text;
            cliente.Endereco = tbEndereco.Text;
            cliente.Telefone = tbTelefone.Text;
            cliente.Email = tbEmail.Text;

            if (rdbPessoaFisica.Checked)
            {   
                cliente.TipoCliente = EnumTipoCliente.PessoaFisica;
                cliente.Cpf = tbCPF.Text;
                cliente.Cnpj = "-";
            }
            else
            {
                cliente.TipoCliente = EnumTipoCliente.PessoaJuridica;
                cliente.Cnpj = tbCNPJ.Text;
                cliente.Cpf = "-";
            }
            
            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void rdbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            tbCNPJ.Text = "";
            tbCNPJ.Enabled = false;
            tbCPF.Enabled = true;
        }

        private void rdbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            tbCPF.Text = "";
            tbCPF.Enabled = false;
            tbCNPJ.Enabled = true;
        }
   
        private void tbNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }
 
        private void TelaCadastroCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroCliente_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");

        }

        private void tbCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbCnh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
            if (tbNome.Text.Length < 2)
            {
                tbNome.Clear();
            }
        }

        private void tbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidarCampoEmail(e);
        }
    }
}
