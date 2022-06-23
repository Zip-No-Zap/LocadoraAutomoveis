using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Cliente
{
    public partial class TelaCadastroCliente : Form
    {
        public Cliente cliente;

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
                tbCnhCondutor.Text = cliente.Cnh;
                tbEmail.Text = cliente.Email;
                tbTelefone.Text = cliente.Telefone;

                if (cliente.TipoCliente == EnumTipoCliente.PessoaFisica)
                {
                    rdbPessoaFisica.Checked = true;
                    tbCPF.Text = cliente.Cnpj;
                    
                }
                else
                {
                    rdbPessoaJuridica.Checked = true;
                    tbCNPJ.Text = cliente.Cnpj;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            cliente.Cnpj = tbCNPJ.Text;
            cliente.Cpf = tbCPF.Text;
            cliente.Endereco = tbEndereco.Text;
            cliente.Cnh = tbCnhCondutor.Text;
            cliente.Telefone = tbTelefone.Text;

            if (rdbPessoaFisica.Checked)
            {
                cliente.TipoCliente = EnumTipoCliente.PessoaFisica;
                cliente.Cpf = tbCPF.Text;
            }
            else
            {
                cliente.TipoCliente = EnumTipoCliente.PessoaJuridica;
                cliente.Cnpj = tbCNPJ.Text;
            }
            

            ValidationResult resultadoValidacao = GravarRegistro(cliente);

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
            e = ImpedirNumeroTexBox(e);
        }
        private static KeyPressEventArgs ImpedirNumeroTexBox(KeyPressEventArgs e)
        {
            if ((Strings.Asc(e.KeyChar) >= 48 & Strings.Asc(e.KeyChar) <= 57))
            {
                e.Handled = true;
                e = null;
            }

            return e;
        }

        private void TelaCadastroCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }
    }
}
