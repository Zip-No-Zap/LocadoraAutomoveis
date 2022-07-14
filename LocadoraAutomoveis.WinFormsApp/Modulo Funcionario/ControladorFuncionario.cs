using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public class ControladorFuncionario : ControladorBase
    {
        readonly ServicoFuncionario servicoFuncionario;
        FuncionarioControl tabelaFuncionarios;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }
         
        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new()
            {
                Funcionario = new(),
                GravarRegistro = servicoFuncionario.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            Funcionario Selecionado = null;

            Result<Funcionario> resultadoResult = ObtemFuncionarioSelecionado();

            if (resultadoResult.IsSuccess)
            {
                Selecionado = resultadoResult.Value;

                if (Selecionado.Id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um funcionário primeiro",
                    "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                TelaCadastroFuncionario tela = new();

                tela.Funcionario = Selecionado;

                tela.GravarRegistro = servicoFuncionario.Editar;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarFuncionarios();
                }
            }
            else if (resultadoResult.IsFailed)
            {
                MessageBox.Show(resultadoResult.Errors[0].Message,
                   "Edição de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public override void Excluir()
        {
            Funcionario Selecionado = null;

            Result<Funcionario> resultadoResult = ObtemFuncionarioSelecionado();

            if (resultadoResult.IsSuccess)
            {
                Selecionado = resultadoResult.Value;

                if (Selecionado.Id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                    "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    servicoFuncionario.Excluir(Selecionado);

                    CarregarFuncionarios();
                }
            }
            else if (resultadoResult.IsFailed)
            {
                MessageBox.Show(resultadoResult.Errors[0].Message,
                   "Exclusão de Funcionários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfigurarStripFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionarios == null)
                tabelaFuncionarios = new FuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }

        private void CarregarFuncionarios()
        {
            Result< List<Funcionario> > resultado = servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                tabelaFuncionarios.AtualizarRegistros(funcionarios);

                FormPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Result<Funcionario> ObtemFuncionarioSelecionado()
        {
            var numero = tabelaFuncionarios.ObtemNumerFuncionarioSelecionado();

            return servicoFuncionario.SelecionarPorId(numero);
        }

    }
}
