using LocadoraAutomoveis.WinFormsApp.ModuloLocacao.Devolucao;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using GeradorTestes.Infra.Arquivo.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using System.Collections.Generic;
using System.Windows.Forms;
using FluentResults;
using System.Linq;
using System;

namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        private Locacao locacao;

        List<Condutor> condutores;
        List<Veiculo> veiculos;
        List<Taxa> taxas;
        List<Plano> planos;
        List<Cliente> clientes;
        List<Locacao> locacoes;
        public bool ehDevolucao;
        public bool verificaFechada;

        StructDevolucao Devolucao;

        public TelaCadastroLocacao(List<Cliente> clientes,
            List<Condutor> condutores, List<Veiculo> veiculos,
            List<Taxa> taxas, List<GrupoVeiculo> grupos, 
            List<Plano> planos, List<Locacao> locacoes, bool ehDevolucao)
        {
            InitializeComponent();
            CarregarClientes(clientes);
            CarregarGrupoVeiculos(grupos);
            this.condutores = condutores;
            this.veiculos = veiculos;
            this.taxas = taxas;
            this.planos = planos;
            this.clientes = clientes;
            this.locacoes = locacoes;
            this.ehDevolucao = ehDevolucao;

            if (ehDevolucao == true)
                ConfigurarBotoesDevolucao();
        }

        private void ConfigurarBotoesDevolucao()
        {
            btnOK.Enabled = false;
            btnLimpar.Enabled = false;
            btnDesmarcar.Enabled = false;
            btnRegistrarDevolucao.Visible = true;
            cmbClientes.Enabled = false;
            cmbCondutor.Enabled = false;
            dpDataLocacao.Enabled = false;
            dpDataDevolucao.Enabled = false;
            cmbPlano.Enabled = false;
            cmbGrupoVeiculo.Enabled = false;
            cmbVeiculo.Enabled = false;
            listTaxasAdicionais.Enabled = false;
            btnCalcular.Enabled = false;
        }

        private void CarregarGrupoVeiculos(List<GrupoVeiculo> grupo)
        {
            cmbVeiculo.Items.Clear();

            foreach (var item in grupo)
            {
                cmbGrupoVeiculo.Items.Add(item);
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro
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
                    cmbCondutor.SelectedItem = locacao.CondutorLocacao;
                else
                    cmbCondutor.SelectedIndex = -1;

                if (locacao.Grupo != null)
                    cmbGrupoVeiculo.SelectedItem = locacao.Grupo;
                else
                    cmbGrupoVeiculo.SelectedIndex = -1;

                if (locacao.VeiculoLocacao != null)
                    cmbVeiculo.SelectedItem = locacao.VeiculoLocacao;
                else
                    cmbVeiculo.SelectedIndex = -1;

                if (locacao.PlanoLocacao != null)
                    cmbPlano.SelectedItem = locacao.PlanoLocacao_Descricao;
                else
                    cmbPlano.SelectedIndex = -1;

                if (locacao.VeiculoLocacao != null)
                    txtKmAtual.Text = locacao.VeiculoLocacao.QuilometragemAtual.ToString();

                dpDataLocacao.Value = locacao.DataLocacao;
                dpDataDevolucao.Value = locacao.DataDevolucao;

                CarregarItensAdicionais();
            }
        }

        private void CarregarItensAdicionais()
        {
            listTaxasAdicionais.Items.Clear();

            if (taxas != null)
            {
                int i = 0;
                foreach (var item in taxas)
                {
                    listTaxasAdicionais.Items.Add(item.ToString());
                    i++;
                }
            }

            AdicionarPlanoAosItensAdicionais(cmbGrupoVeiculo.Text);

            MarcarItensDeEdicao();
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (var item in clientes)
                cmbClientes.Items.Add(item);
        }

        private GrupoVeiculo CarregarVeiculos()
        {
            cmbVeiculo.Items.Clear();

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

            lblTotalPrevisto.Text = locacao.TotalPrevisto.ToString("N2");

            if(btnLimpar.Enabled == false)
            {
                this.Text = "Devolução";
                lblTotalMarcador.Text = "Total a Pagar R$";
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCondutor.Items.Clear();

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
            VerificarCampoVAzio();

            locacao.ClienteLocacao = (Cliente)cmbClientes.SelectedItem;
            locacao.CondutorLocacao = (Condutor)cmbCondutor.SelectedItem;
            locacao.VeiculoLocacao = (Veiculo)cmbVeiculo.SelectedItem;
            locacao.DataLocacao = Convert.ToDateTime(dpDataLocacao.Text);
            locacao.DataDevolucao = Convert.ToDateTime(dpDataDevolucao.Text);
            locacao.Grupo = (GrupoVeiculo)cmbGrupoVeiculo.SelectedItem;
          
            AlterarStatusVeiculo();

            AlterarStatusLocacao();

            ReceberPlano();

            ReceberTaxa();

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsSuccess == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                FormPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void ReceberTaxa()
        {
            foreach (var item in listTaxasAdicionais.CheckedItems)
            {
                if (item.ToString().Contains("Plano"))
                    continue;
                else
                {
                    string separador = item.ToString().Split("-")[0].Trim();
                    var selecionado = taxas.Find(x => x.Descricao.Contains(separador));
                    locacao.ItensTaxa.Add(selecionado);
                }
            }
        }

        private void ReceberPlano()
        {
            var planoSelecionado = planos.Find(x => x.Grupo.Nome == cmbGrupoVeiculo.Text);
            locacao.PlanoLocacao = planoSelecionado;
        }

        private void AlterarStatusVeiculo()
        {
            if (locacao.VeiculoLocacao != null)
            {
                locacao.VeiculoLocacao.QuilometragemAtual = float.Parse(txtKmAtual.Text);

                switch (locacao.VeiculoLocacao.situacao)
                {
                    case "alugado":
                        locacao.VeiculoLocacao.StatusVeiculo = "Alugado";
                        break;

                    case "disponível":
                        locacao.VeiculoLocacao.StatusVeiculo = "Disponível";
                        break;

                    default:
                        break;
                }
            }
        }

        private void AlterarStatusLocacao()
        {
            switch (locacao._estaLocado)
            {
                case "sim":
                    locacao.Status = "Aberta";
                    break;

                case "não":
                    locacao.Status = "Fechada";
                    break;

                default:
                    break;
            }
        }

        private void cmbGrupoVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrupoVeiculo grupo = CarregarVeiculos();
        }

        private void AdicionarPlanoAosItensAdicionais(string nomeGrupo)
        {
            Locacao.PlanoLocacao_Descricao = cmbPlano.Text;

            var planoSelecionado = planos.Find(x => x.Grupo.Nome == nomeGrupo);

            switch (cmbPlano.Text)
            {
                case "Diário":
                    listTaxasAdicionais.Items.Add($"Plano {Locacao.PlanoLocacao_Descricao:N2} - Valor Diário: R$ {planoSelecionado.ValorDiario_Diario:N2}  - Valor por Km Rodado: R$ {planoSelecionado.ValorPorKm_Diario:N2}");
                    listTaxasAdicionais.SetItemChecked(listTaxasAdicionais.Items.Count -1, true);
                    break;

                case "Livre":
                    listTaxasAdicionais.Items.Add($"Plano {Locacao.PlanoLocacao_Descricao:N2} - Valor Diário: R$ {planoSelecionado.ValorDiario_Livre:N2}");
                    listTaxasAdicionais.SetItemChecked(listTaxasAdicionais.Items.Count -1, true);
                    break;

                case "Controlado":
                    listTaxasAdicionais.Items.Add($"Plano {Locacao.PlanoLocacao_Descricao:N2} - Valor Diário: R$ {planoSelecionado.ValorDiario_Controlado:N2} - Valor por Km Rodado: R$ {planoSelecionado.ValorPorKm_Controlado:N2} Limite de Quilometragem: {planoSelecionado.LimiteQuilometragem_Controlado}");
                    listTaxasAdicionais.SetItemChecked(listTaxasAdicionais.Items.Count -1, true);
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

            lblTotalPrevisto.Text = Locacao.TotalPrevisto.ToString("N2");
        }

        private void CalcularItensAdicionais()
        {
            var checados = listTaxasAdicionais.CheckedItems;

            foreach (var item in checados)
            {
                string separador = item.ToString().Split("-")[0].Trim();
                var taxa = taxas.Find(x => x.Descricao.Contains(separador));

                if (taxa != null)
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

        private void DesmarcarCheckBoxes()
        {
            var totalItens = listTaxasAdicionais.Items.Count;

            for (int i = 0; i < totalItens; i++)
            {
                listTaxasAdicionais.SetItemChecked(i, false);
            }
        }

        private void CarregarRichTextLocacao()
        {
            string detalhe =
            $"\n" +
            $"------------------------------------------------------------------------" +
            $"DETALHES DA LOCAÇÃO \n\r" +
            $"Total: R$ {locacao.TotalPrevisto.ToString("N2")} \n\r" +
            $"------------------------------------------------------------------------" +
            $"Data Locação: {dpDataLocacao.Text} \n\r" +
            $"Data Devolução: {dpDataDevolucao.Text}\n\r" +
            $"Status Locação: {locacao.Status}\n\r" +
            $"------------------------------------------------------------------------" +
            $"Cliente: {cmbClientes.Text} \n\r" +
            $"Condutor: {cmbCondutor.Text}  \n\r" +
            $"CNH: {locacao.CondutorLocacao.Cnh} \n\r" +
            $"------------------------------------------------------------------------" +
            $"Grupo: {cmbGrupoVeiculo.Text}  \n\r" +
            $"Veículo: {cmbVeiculo.Text}  \n\r" +
            $""+
            $"Placa: { locacao.VeiculoLocacao.Placa}  \n\r" +
            $"Quilometragem Registrada: { txtKmAtual.Text}\n\r" +
            $"------------------------------------------------------------------------" +
            $"Itens Adicionais: \n\n\r"
            ;

            rtPDF.Text = detalhe;

            CarregarItensRichText();
        }

        private void CarregarRichTextDevolucao()
        {
            string detalhe =
            $"\n" +
            $"------------------------------------------------------------------------" +
            $"DETALHES DA DEVOLUÇÃO \n\r" +
            $"Total: R$ {locacao.TotalPrevisto.ToString("N2")} \n\r" +
            $"------------------------------------------------------------------------" +
            $"Data Locação: {locacao.DataLocacao.ToShortDateString()} \n\r" +
            $"Data Devolução: {locacao.DataDevolucao.ToShortDateString()}\n\r" +
            $"Devolvido dia: {locacao.DataDevolvidoDeFato.ToShortDateString()}\n\r" +
            $"Status Locação: {locacao.Status}\n\r" +
            $"------------------------------------------------------------------------" +
            $"Cliente: {cmbClientes.Text} \n\r" +
            $"Condutor: {cmbCondutor.Text}  \n\r" +
            $"CNH: {locacao.CondutorLocacao.Cnh} \n\r" +
            $"------------------------------------------------------------------------" +
            $"Grupo: {cmbGrupoVeiculo.Text}  \n\r" +
            $"Veículo: {cmbVeiculo.Text}  \n\r" +
            $"Placa: {locacao.VeiculoLocacao.Placa}  \n\r" +
            $"Quilometragem Registrada: {locacao.VeiculoLocacao.QuilometragemAtual}\n\r" +
            $"Nível Tanque: {locacao.NivelTanqueVeiculo}\n\r" +
            $"------------------------------------------------------------------------" +
            $"Valor calculado plano: R$ {Devolucao.calcPlano.ToString("N2")}\n\r" +
            $"Valor calculado quilometragem: R$ {Devolucao.diferencaKm.ToString("N2")}\n\r" +
            $"Valor calculado tanque: R$ {Devolucao.diferencaTanque.ToString("N2")}\n\r" +
            $"Valor calculado atraso: R4 {Devolucao.diasAtraso.ToString("N2")}\n\r" +
            $"------------------------------------------------------------------------" +
            $"Descrição dos Itens Adicionais: \n\n\r"
            ;

            rtPDF.Text = detalhe;

            CarregarItensRichText();
        }

        private void CarregarItensRichText()
        {
            foreach (var item in listTaxasAdicionais.CheckedItems)
            {
                rtPDF.Text += item.ToString() + "\n";
            }
        }

        public void GerarPdf()
        {
            if (btnLimpar.Enabled == true)
                CarregarRichTextLocacao();
            else
                CarregarRichTextDevolucao();

            GeradorPdf pdf = new();

            pdf.GerarPDF_ItextSharp(rtPDF.Text, cmbClientes.Text);

            MessageBox.Show("Arquivo PDF Gerado!\n\nDestino: C: -> temp -> pdf -> ComprovanteLocacao_.pdf");
        }

        private void MarcarItensDeEdicao()
        {
            string nomeCliente = cmbClientes.Text;

            if(nomeCliente != null && locacao.ItensTaxa != null)
            {
                var clienteSelecionado = clientes.Find(x => x.Nome == nomeCliente);
                var locacaoSelecionada = locacoes.Find(x => x.ClienteLocacao.Equals(clienteSelecionado));

                for(int i = 0; i < listTaxasAdicionais.Items.Count; i++)
                {
                    var item = listTaxasAdicionais.Items[i];
                    string cortado = item.ToString().Split("-")[0].Trim();

                    foreach (var taxa in locacao.ItensTaxa)
                    {
                        if (cortado == taxa.Descricao)
                            listTaxasAdicionais.SetItemChecked(i, true);
                    }
                }
            }

            MarcarPlanosNosItensEdicao();
        }

        private void MarcarPlanosNosItensEdicao()
        {
            Locacao.PlanoLocacao_Descricao = cmbPlano.Text;

            for (int i = 0; i < listTaxasAdicionais.Items.Count; i++)
            {
                if (listTaxasAdicionais.Items[i].ToString().Contains("Plano"))
                    listTaxasAdicionais.SetItemChecked(i, true);
            }

        }

        private void btnDesmarcar_Click_1(object sender, EventArgs e)
        {
            DesmarcarCheckBoxes();
            lblTotalPrevisto.Text = "0,00";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cmbClientes.Items.Clear();
            cmbCondutor.Items.Clear();
            dpDataLocacao.Value = DateTime.Today;
            dpDataDevolucao.Value = DateTime.Today;
            cmbGrupoVeiculo.Items.Clear();
            cmbVeiculo.Items.Clear();
            txtKmAtual.Clear();
            cmbPlano.Items.Clear();
            lblTotalPrevisto.Text = "0,00";
            DesmarcarCheckBoxes();
        }

        private void btnDevolucao_Click(object sender, EventArgs e)
        {
            TelaDevolucao telaDevolucao = new();

            telaDevolucao.Devolucao.dataLocacao = locacao.DataLocacao;
            telaDevolucao.Devolucao.quilometragemAnterior = locacao.VeiculoLocacao.QuilometragemAtual;
            telaDevolucao.Devolucao.totalPrevisto = locacao.TotalPrevisto;
            telaDevolucao.Devolucao.plano = locacao.PlanoLocacao_Descricao;
            telaDevolucao.Devolucao.tanqueMaximoVeiculo = locacao.VeiculoLocacao.CapacidadeTanque;
            telaDevolucao.Devolucao.tipoCombustivel = locacao.VeiculoLocacao.TipoCombustivel;
            telaDevolucao.Devolucao.dataDevolucaoLocacao = locacao.DataDevolucao;
            telaDevolucao.Devolucao.diario_valorDiario = locacao.PlanoLocacao.ValorDiario_Diario;
            telaDevolucao.Devolucao.diario_valorPoKmRodado = locacao.PlanoLocacao.ValorPorKm_Diario;
            telaDevolucao.Devolucao.livre_valorDiario = locacao.PlanoLocacao.ValorDiario_Livre;
            telaDevolucao.Devolucao.controlado_valorDiario = locacao.PlanoLocacao.ValorDiario_Livre;
            telaDevolucao.Devolucao.controlado_valorKmRodado = locacao.PlanoLocacao.ValorDiario_Livre;
            telaDevolucao.Devolucao.controlado_limiteKm = locacao.PlanoLocacao.LimiteQuilometragem_Controlado;
            telaDevolucao.Devolucao.taxasDiarias = locacao.ItensTaxa.FindAll(x => x.Tipo == "Diário");
 
            this.Devolucao = telaDevolucao.Devolucao;

            switch (telaDevolucao.Devolucao.plano)
            {
                case "Díário":
                    telaDevolucao.Devolucao.diario_valorPoKmRodado = locacao.PlanoLocacao.ValorPorKm_Diario;
                    telaDevolucao.Devolucao.diario_valorDiario = locacao.PlanoLocacao.ValorDiario_Diario;
                    break;

                case "Livre":
                    telaDevolucao.Devolucao.diario_valorDiario = locacao.PlanoLocacao.ValorDiario_Livre;
                    break;

                case "Controlado":
                    telaDevolucao.Devolucao.diario_valorDiario = locacao.PlanoLocacao.ValorDiario_Controlado;
                    telaDevolucao.Devolucao.diario_valorPoKmRodado = locacao.PlanoLocacao.ValorPorKm_Controlado;
                    telaDevolucao.Devolucao.controlado_limiteKm = locacao.PlanoLocacao.LimiteQuilometragem_Controlado;
                    break;
            }

            if (telaDevolucao.ShowDialog() == DialogResult.OK)
            {
                locacao.TotalPrevisto = telaDevolucao.Devolucao.totalDeFato;
                lblTotalMarcador.Text = "Total a Pagar R$";
                lblTotalPrevisto.Text = locacao.TotalPrevisto.ToString("N2");
                locacao._estaLocado = "não";
                btnOK.Enabled = true;
                txtKmAtual.Text = telaDevolucao.Devolucao.quilometragemAtualizada.ToString();
                locacao.VeiculoLocacao.situacao = "disponível";
                locacao.DataDevolucao = telaDevolucao.Devolucao.dataDevolvido;
                locacao.DataDevolvidoDeFato = telaDevolucao.Devolucao.dataDevolvido;
                locacao.NivelTanqueVeiculo = telaDevolucao.Devolucao.nivelTanque;

                btnCalcular.Enabled = false;

                Devolucao.diferencaTanque = telaDevolucao.Devolucao.diferencaTanque;
                Devolucao.diferencaKm = telaDevolucao.Devolucao.diferencaKm;
                Devolucao.calcPlano = telaDevolucao.Devolucao.calcPlano;
                Devolucao.calcTaxasDiarias = telaDevolucao.Devolucao.calcTaxasDiarias;

                if(Devolucao.diasAtraso != telaDevolucao.Devolucao.diasAtraso)
                    Devolucao.diasAtraso = telaDevolucao.Devolucao.diasAtraso;
            }
        }

        private void VerificarCampoVAzio()
        {
            if (cmbClientes.SelectedItem == null)
                locacao.ClienteLocacao = null;

            if (cmbCondutor.SelectedItem == null)
                locacao.CondutorLocacao = null;

            if (cmbPlano.SelectedItem == null)
            {
                locacao.PlanoLocacao = null;
                locacao.PlanoLocacao_Descricao = "";
            }

            if (cmbVeiculo.SelectedItem == null)
                locacao.VeiculoLocacao = null;

            if (cmbGrupoVeiculo.SelectedItem == null)
                locacao.Grupo = null;
        }
    }

}
