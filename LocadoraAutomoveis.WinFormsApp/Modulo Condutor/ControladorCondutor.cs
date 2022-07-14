using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Cliente;
using LocadoraAutomoveis.Aplicacao.Modulo_Condutor;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
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
            Result<List<Cliente>> resultadoResult = servicoCliente.SelecionarTodos();

            if (resultadoResult.IsSuccess)
            {
                List<Cliente> clientes = resultadoResult.Value;

                TelaCadastroCondutor tela = new(clientes)
                {
                    Condutor = new(),

                    GravarRegistro = servicoCondutor.Inserir
                };

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarCondutores();
                }
            }
        }

        public override void Editar()
        {
            Condutor selecionado = null;
            List<Cliente> selecionadoClientes = null; 

            Result<Condutor> resultadoResult = ObtemCondutorSelecionado();

            Result<List<Cliente>> resultadocliente = servicoCliente.SelecionarTodos();

            if (resultadoResult.IsSuccess && resultadocliente.IsSuccess)
            {
                selecionado = resultadoResult.Value;

                selecionadoClientes = resultadocliente.Value;

                if (selecionado.Id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um condutor primeiro",
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                TelaCadastroCondutor tela = new(selecionadoClientes)
                {
                    Condutor = selecionado,

                    GravarRegistro = servicoCondutor.Editar
                };

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarCondutores();
                }
            }
            else if (resultadoResult.IsFailed)
            {
                MessageBox.Show(resultadoResult.Errors[0].Message,
                   "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                    servicoCondutor.Excluir(selecionado);

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
