using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Condutor
{
    public class ControladorCondutor : ControladorBase
    {
        readonly ServicoCondutor servicoCondutor;
        readonly ServicoCliente servicoCliente;

        CondutorControl tabelaCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }
        public override void Inserir()
        {
            TelaCadastroCondutor tela = new(servicoCliente.SelecionarTodos())
            {
                Condutor = new() { Cliente = new()},

                GravarRegistro = servicoCondutor.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            Condutor Selecionado = ObtemCondutorSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutor tela = new(servicoCliente.SelecionarTodos())
            {
                Condutor = Selecionado,

                GravarRegistro = servicoCondutor.Editar
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }

        }
        public override void Excluir()
        {
            Condutor selecionado = ObtemCondutorSelecionado();

            if (selecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoCondutor.Excluir(selecionado);

                CarregarCondutores();
            }

        }


        private Condutor ObtemCondutorSelecionado()
        {
            var numero = tabelaCondutor.ObtemNumerCondutorSelecionado();

            return servicoCondutor.SelecionarPorId(numero);
        }

        
        
        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCondutor == null)
                tabelaCondutor = new CondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = servicoCondutor.SelecionarTodos();

            tabelaCondutor.AtualizarRegistros(condutores);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
        }

    }
}
