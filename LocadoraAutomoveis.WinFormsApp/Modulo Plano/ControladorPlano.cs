using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public  class ControladorPlano : ControladorBase
    {
        ServicoPlano servicoPlano;
        PlanoControl tabelaPlanos;

        public ControladorPlano(ServicoPlano servicoPlano)//TODO : terminar o ControladorPlano
        {
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            TelaCadastroPlano tela = new();
            tela.Plano = new();

            tela.GravarRegistro = servicoPlano.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Editar()
        {
            Plano Selecionado = ObtemPlanoSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione uma Plano primeiro",
                "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPlano tela = new();

            tela.Plano = Selecionado;

            tela.GravarRegistro = servicoPlano.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Excluir()
        {
            Plano Selecionado = ObtemPlanoSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione uma Plano primeiro",
                "Exclusão de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Plano?",
                "Exclusão de Plano", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoPlano.Excluir(Selecionado);

                CarregarPlanos();
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfiguracaoStripPlano();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanos == null)
                tabelaPlanos = new PlanoControl();

            CarregarPlanos();

            return tabelaPlanos;
        }

        private void CarregarPlanos()
        {
            List<Plano> Planos = servicoPlano.SelecionarTodos();

            tabelaPlanos.AtualizarRegistros(Planos);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {Planos.Count} Plano(s)");
        }

        private Plano ObtemPlanoSelecionado()
        {
            var numero = tabelaPlanos.ObtemNumerPlanoSelecionado();

            return servicoPlano.SelecionarPorId(numero);
        }
    }
}
