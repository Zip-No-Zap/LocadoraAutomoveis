using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

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
            Result<List<Cliente>> resultadoResult = servicoCliente.SelecionarTodos();

            var clientes = servicoCliente.SelecionarTodos().Value;

            var tela = new TelaCadastroCondutor(clientes);

            if (resultadoResult.IsSuccess)
            {
                tela.Condutor = new(); 

                tela.GravarRegistro = servicoCondutor.Inserir;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarCondutores();
                }
            }
        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemNumerCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selecionado = resultado.Value;

            Result<List<Cliente>> resultadocliente = servicoCliente.SelecionarTodos();

            var selecionadoClientes = resultadocliente.Value;

            TelaCadastroCondutor tela = new(selecionadoClientes);

            tela.Condutor = selecionado;

            tela.GravarRegistro = servicoCondutor.Editar;


            if (tela.ShowDialog() == DialogResult.OK)

                CarregarCondutores();
        }

        public override void Excluir()
        {
            Condutor selecionado = null;

            Result<Condutor> resultadoResult = ObtemCondutorSelecionado();

            if (resultadoResult.IsSuccess)
            {
                selecionado = resultadoResult.Value;

                if (selecionado.Id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um Condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Condutor?",
                    "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    var exclusaoResult = servicoCondutor.Excluir(selecionado);

                    if (exclusaoResult.IsFailed)
                        MessageBox.Show("Não foi possível excluir este condutor!\n\n" + exclusaoResult.Errors[0], "Aviso");

                    CarregarCondutores();
                }
            }
            else if (resultadoResult.IsFailed)
            {
                MessageBox.Show(resultadoResult.Errors[0].Message,
                   "Excluir de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private Result<Condutor> ObtemCondutorSelecionado()
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
            Result<List<Condutor>> resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                tabelaCondutor.AtualizarRegistros(condutores);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
