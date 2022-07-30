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
using System.Linq;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        private Locacao locacao;

        List<Condutor> condutores;
        List<Veiculo> veiculos;
        List<Taxa> taxas;
        List<GrupoVeiculo> grupos;
        List<Plano> planos;
        public TelaCadastroLocacao(List<Cliente> clientes, 
            List<Condutor> condutores, List<Veiculo> veiculos, 
            List<Taxa> taxas, List<GrupoVeiculo> grupos, List<Plano> planos)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            CarregarGrupoVeiculos(grupos);
            this.condutores = condutores;
            this.veiculos = veiculos;
            this.taxas = taxas;
            this.planos = planos;
            this.grupos = grupos;
        }

        private void CarregarGrupoVeiculos(List<GrupoVeiculo> grupo)
        {
            cmbVeiculo.Items.Clear();

            foreach (var item in grupo)
            {
                cmbGrupoVeiculo.Items.Add(item);
            }
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

                if (locacao.VeiculoLocacao != null)
                    cmbVeiculo.SelectedItem = locacao.VeiculoLocacao;
                else
                    cmbVeiculo.SelectedIndex = -1;

                CarregarItensAdicionais();
            }
        }

        private void CarregarItensAdicionais()
        {
            if (taxas != null)
            {
                int i = 0;
                foreach (var item in taxas)
                {
                    listTaxasAdicionais.Items.Add(item.ToString());
                    i++;
                }
            }
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (var item in clientes)
                cmbClientes.Items.Add(item);
        }
        private GrupoVeiculo CarregarVeiculos()
        {
            var grupo = (GrupoVeiculo)cmbGrupoVeiculo.SelectedItem;

            foreach (var item in veiculos)
            {
                if (item.GrupoPertencente.Equals(grupo))
                {
                    cmbVeiculo.Items.Add(item);
                }
            }

            return grupo;
        }

        private void TelaCadastroLocacao_Load(object sender, EventArgs e)
        {
            FormPrincipal.Instancia.AtualizarRodape("");
        }

         private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cliente = (Cliente)cmbClientes.SelectedItem;

            var condutoresCliente = condutores.FindAll(x => x.Cliente.Equals(cliente)).ToList();

            foreach (var item in condutoresCliente)
            {
                cmbCondutor.Items.Add(item);
            }
        }

        private void cmbVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var veiculo = (Veiculo)cmbVeiculo.SelectedItem;
            txtKmAtual.Text = veiculo.QuilometragemAtual.ToString();

        }

        private void cmbPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdicionarPlanoAosItensAdicionais(cmbGrupoVeiculo.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            locacao.ClienteLocacao = (Cliente)cmbClientes.SelectedItem;
           
            locacao.CondutorLocacao = (Condutor)cmbCondutor.SelectedItem;
           
            locacao.VeiculoLocacao = (Veiculo)cmbVeiculo.SelectedItem;

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cmbGrupoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrupoVeiculo grupo = CarregarVeiculos();

            HabilitarPlanos(grupo);
        }

        private bool VerificarSeGrupoTemPlano(GrupoVeiculo grupo)
        {
            var grupoSelecionado = planos.Find(x => x.Grupo.Equals(grupo));

            bool temPlano = grupoSelecionado != null;

            return temPlano;
        }

        private void HabilitarPlanos(GrupoVeiculo grupo)
        {
            if (VerificarSeGrupoTemPlano(grupo))
                cmbPlano.Enabled = true;
        }

        private void AdicionarPlanoAosItensAdicionais(string nomeGrupo)
        {
            Locacao.PlanoLocacao_Descricao = cmbPlano.Text;

            var planoSelecionado = planos.Find(x => x.Grupo.Nome == nomeGrupo);

            switch (cmbPlano.Text)
            {
                case "Diário":
                    listTaxasAdicionais.Items.Add("Plano " + Locacao.PlanoLocacao_Descricao + " - " + "Valor Diário: R$ " + planoSelecionado.ValorDiario_Diario + " - " + "Valor por Km Rodado: R$ " + planoSelecionado.ValorPorKm_Diario);
                    break;

                case "Livre":
                    listTaxasAdicionais.Items.Add("Plano " + Locacao.PlanoLocacao_Descricao + " - " + "Valor Diário: R$ " + planoSelecionado.ValorDiario_Livre);
                    break;

                case "Controlado":
                    listTaxasAdicionais.Items.Add("Plano " + Locacao.PlanoLocacao_Descricao + " - " + "Valor Diário: R$ " + planoSelecionado.ValorDiario_Controlado + " - " + "Valor por Km Rodado: R$ " + planoSelecionado.ValorPorKm_Controlado + "Limite de Quilometragem: " + planoSelecionado.LimiteQuilometragem_Controlado);
                    break;

                default:
                    break;
            }
        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            var itensChecados = listTaxasAdicionais.Items.Count;

            for (int i = 0; i < itensChecados; i++)
            {
                listTaxasAdicionais.SetItemChecked(i, false);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            locacao.TotalPrevisto = 0;

            CalcularItensAdicionais();

            CalcularPlanos();

            lblTotalPrevisto.Text = Locacao.TotalPrevisto.ToString();
        }

        private void CalcularItensAdicionais()
        {
            var checados = listTaxasAdicionais.CheckedItems;

            foreach (var item in checados)
            {
                var taxa = taxas.Find(x => x.Descricao.Contains(item.ToString().Remove(15)));

                if(taxa != null)
                    locacao.TotalPrevisto += taxa.Valor;
            }
        }

        private void CalcularPlanos()
        {
            var planoSelecionado = planos.Find(x => x.Grupo.Nome == cmbGrupoVeiculo.Text);

            switch (locacao.PlanoLocacao_Descricao)
            {
                case "Diário":
                    locacao.TotalPrevisto += planoSelecionado.ValorDiario_Diario;
                    break;

                case "Livre":
                    locacao.TotalPrevisto += planoSelecionado.ValorDiario_Livre;
                    break;

                case "Controlado":
                    locacao.TotalPrevisto += planoSelecionado.ValorDiario_Controlado;
                    break;

                default:
                    break;
            }
        }

        private void btnDesmarcar_Click_1(object sender, EventArgs e)
        {
            var totalItens = listTaxasAdicionais.Items.Count;

            for (int i = 0; i < totalItens; i++)
            {
                listTaxasAdicionais.SetItemChecked(i, false);
            }
        }
    }

}
