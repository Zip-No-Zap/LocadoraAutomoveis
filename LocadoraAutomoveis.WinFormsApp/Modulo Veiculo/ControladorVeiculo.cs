using LocadoraAutomoveis.Aplicacao.Modulo_Veiculo;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        readonly ServicoVeiculo servicoVeiculo;
        VeiculoControl tabelaVeiculos;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo)
        {
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroVeiculo tela = new()
            {
                Veiculo = new(),
                GravarRegistro = servicoVeiculo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }



        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }



        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }

        private void CarregarVeiculos()
        {
            throw new NotImplementedException();
        }
    }
}
