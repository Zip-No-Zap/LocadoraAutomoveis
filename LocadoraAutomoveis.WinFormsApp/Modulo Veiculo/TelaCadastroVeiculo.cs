using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private Veiculo veiculo;

        public Func<Veiculo, ValidationResult> GravarRegistro
        {
            get; set;
        }

        public Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }
            set
            {
                veiculo = value;

                txbModelo.Text = veiculo.Modelo;
                txbPlaca.Text = veiculo.Placa;
                txbCor.Text = veiculo.Cor;
                txbAno.Text = veiculo.Ano.ToString();
                cmbTipoCombustivel.SelectedItem = veiculo.TipoCombustivel;
                txbCapacidadeTanque.Text = veiculo.CapacidadeTanque.ToString();
                cmbGrupoVeiculo.SelectedItem = veiculo.GrupoPertencente;
                cmbStatus.SelectedItem = veiculo.StatusVeiculo;
                txbQuilometragemAtual.Text = veiculo.QuilometragemAtual.ToString();
            }
        }
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
        }

      
    }
}
