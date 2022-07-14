using FluentResults;
using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
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
            Funcionario Selecionado = ObtemFuncionarioSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Edição de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public override void Excluir()
        {
            Funcionario Selecionado = ObtemFuncionarioSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um Funcionario primeiro",
                "Exclusão de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Funcionario?",
                "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoFuncionario.Excluir(Selecionado);

                CarregarFuncionarios();
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

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var numero = tabelaFuncionarios.ObtemNumerFuncionarioSelecionado();

            return servicoFuncionario.SelecionarPorId(numero);
        }

    }
}
