using LocadoraAutomoveis.Aplicacao.Modulo_Funcionario;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public class ControladorFuncionario : ControladorBase
    {
        readonly RepositorioFuncionarioEmBancoDados repoFuncionario;
        FuncionarioControl tabelaFuncionarios;
        readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            repoFuncionario = new();
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new();
            tela.Funcionario = new();

            tela.GravarRegistro = repoFuncionario.Inserir;

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

            tela.GravarRegistro = repoFuncionario.Editar;

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
                repoFuncionario.Excluir(Selecionado);

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
            List<Funcionario> funcionarios = repoFuncionario.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionario(s)");
        }

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var numero = tabelaFuncionarios.ObtemNumerFuncionarioSelecionado();

            return repoFuncionario.SelecionarPorId(numero);
        }

    }
}
