using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
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
    }
}
