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
                tbCPF.Text = cliente.Cnpj;
                tbCidade.Text = funcionario.Cidade;
                cbUF.Text = funcionario.Estado;
                tbLogin.Text = funcionario.Login;
                tbSenha.Text = funcionario.Senha;
                cbTipoCliente.Text = funcionario.Perfil;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
