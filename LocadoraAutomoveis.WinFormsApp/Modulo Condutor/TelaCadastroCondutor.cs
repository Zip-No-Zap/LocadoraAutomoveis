using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                txtDataVencimentoCnh.Value = condutor.VencimentoCnh;
                cmbClientes.SelectedItem = condutor.Cliente;
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
            condutor.Cliente = (Cliente)cmbClientes.SelectedItem;

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
