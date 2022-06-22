using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public partial class TelaCadasrtoFuncionario : Form
    {
        private Funcionario funcionario;

        public TelaCadasrtoFuncionario()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }
            set
            {
                funcionario = value;

                tbNome.Text = funcionario.Nome;
                tbSalario.Text = funcionario.Salario.ToString();
                tbData.Text = funcionario.DataAdmissao.ToString();
                tbCidade.Text = funcionario.Cidade;
                tbUF.Text = funcionario.Estado;
                tbLogin.Text = funcionario.Login;
                tbSenha.Text = funcionario.Senha;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tbSenha.Text = "";
            tbSenha.PasswordChar = '*';
            tbSenha.MaxLength = 14;
        }

        private void TelaCadasrtoFuncionario_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            funcionario.Nome = tbNome.Text;
       
            funcionario.Salario = float.Parse(tbSalario.Text);
            funcionario.DataAdmissao = Convert.ToDateTime(tbData.Text);
            funcionario.Cidade = tbCidade.Text;
            funcionario.Estado = tbUF.Text;
            funcionario.Login = tbLogin.Text;
            funcionario.Senha = tbSenha.Text;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            tbNome.Clear();
            tbSalario.Clear();
            tbData.Clear();
            tbCidade.Clear();
            tbUF.Clear();
            tbLogin.Clear();
            tbSenha.Clear();

            tbNome.Focus();
        }

        private void TelaCadasrtoFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }
    }
}
