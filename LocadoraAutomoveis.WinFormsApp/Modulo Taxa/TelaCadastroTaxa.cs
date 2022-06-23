using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public partial class TelaCadastroTaxa : Form
    {
        private Taxa taxa;

        public Func<Taxa, ValidationResult> GravarRegistro
        {
            get; set;
        }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }
            set
            {
                taxa = value;

                //tbNome.Text = Taxa.Nome;
                //tbSalario.Text = Taxa.Salario.ToString();
                //tbData.Text = Taxa.DataAdmissao.ToString();
                //tbCidade.Text = Taxa.Cidade;
                //cbUF.Text = Taxa.Estado;
                //tbLogin.Text = Taxa.Login;
                //tbSenha.Text = Taxa.Senha;
                //cbPerfil.Text = Taxa.Perfil;
            }
        }
        public TelaCadastroTaxa()
        {
            InitializeComponent();
        }


    }
}
