using FluentResults;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Dominio.Modulo_Plano;
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

        List<Condutor> condutores;
        List<Veiculo> veiculos;
        List<Taxa> taxas;

        public TelaCadastroLocacao(List<Cliente> clientes, 
            List<Condutor> condutores, List<GrupoVeiculo> grupos,
            List<Veiculo> veiculos, List<Taxa> taxasAdicionais)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            CarregarGrupos(grupos);
            this.condutores = condutores;
            this.veiculos = veiculos;
            this.taxas = taxasAdicionais;
        }

        private void CarregarGrupos(List<GrupoVeiculo> grupos)
        {
            cmbGrupoVeiculo.Items.Clear();

            foreach (var item in grupos)
            cmbGrupoVeiculo.Items.Add(item);
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (var item in clientes)
                cmbClientes.Items.Add(item);
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

                if (locacao.ClienteLocacao != null)
                    cmbClientes.SelectedItem = locacao.ClienteLocacao;
                else
                    cmbClientes.SelectedIndex = -1;

                if (locacao.CondutorLocacao != null)
                    cmbClientes.SelectedItem = locacao.CondutorLocacao;
                else
                    cmbClientes.SelectedIndex = -1;

                dpDataLocacao.Value = locacao.DataLocacao;
                dpDataDevolucao.Value = locacao.DataLocacao;
               
                if (locacao.VeiculoLocacao_Grupo != null)
                    cmbGrupoVeiculo.SelectedItem = locacao.VeiculoLocacao_Grupo;
                else
                    cmbGrupoVeiculo.SelectedIndex = -1;


                if (locacao.VeiculoLocacao != null)
                    cmbVeiculo.SelectedItem = locacao.VeiculoLocacao;
                else
                    cmbVeiculo.SelectedIndex = -1;

                if (taxas != null)
                {
                    int i = 0;
                    foreach (var item in taxas)
                    {
                        listTaxasAdicionais.Items.Add(item);

                        if(locacao.ItensTaxa.Contains(item))
                            listTaxasAdicionais.SetItemChecked(i, true);

                        i++;
                    }
                }
            }
        }

        private void TelaCadastroLocacao_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            locacao.ClienteLocacao = (Cliente)cmbClientes.SelectedItem;
            if (locacao.ClienteLocacao == null)
            {
                var novoClienteVazio = new Cliente() { Nome= "" };
                locacao.ClienteLocacao = novoClienteVazio;
            }

            locacao.CondutorLocacao = (Condutor)cmbCondutor.SelectedItem;
            if (locacao.CondutorLocacao == null)
            {
                var novoClienteVazio = new Condutor();
                locacao.CondutorLocacao = novoClienteVazio;
            }
            //condutor.Nome = tbNome.Text;
            //condutor.Cpf = tbCpf.Text;
            //condutor.Telefone = tbTelefone.Text;
            //condutor.Email = tbEmail.Text;
            //condutor.Endereco = tbEndereco.Text;
            //condutor.Cnh = tbCnh.Text;
            //condutor.VencimentoCnh = txtDataVencimentoCnh.Value;





            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cliente = (Cliente)cmbClientes.SelectedItem;
           
            var condutoresCliente = condutores.FindAll(x => x.Cliente.Equals(cliente));

            foreach (var item in condutoresCliente)
            {
                cmbCondutor.Items.Add(condutoresCliente);
            }

        }
    }
}
