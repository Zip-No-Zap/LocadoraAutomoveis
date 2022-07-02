using LocadoraAutomoveis.Aplicacao.Modulo_Plano;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public  class ControladorPlano : ControladorBase
    {
        ServicoPlano servicoPlano;
        PlanoControl tabelaPlanos;

        public ControladorPlano(ServicoPlano servicoPlano)
        {
            this.servicoPlano = servicoPlano;
        }

        public override void Inserir()
        {
            TelaCadastroPlano tela = new()
            {
                Plano = new()
                {
                    Grupo = new(null)
                },
                
                GravarRegistro = servicoPlano.Inserir
            };


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
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPlano tela = new()
            {
                Plano = Selecionado,

                GravarRegistro = servicoPlano.Editar
            };

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
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Planos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano?",
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
