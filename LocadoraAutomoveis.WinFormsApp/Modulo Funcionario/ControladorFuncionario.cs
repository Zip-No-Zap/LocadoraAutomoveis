using FluentValidation.Results;
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
        RepositorioFuncionarioEmBancoDados repoFuncionario;
        FuncionarioControl tabelaFuncionarios;

        public ControladorFuncionario()
        {
            repoFuncionario = new();
        }

        public override void Inserir()
        {
            TelaCadasrtoFuncionario tela = new();
            tela.Funcionario = new();

            repoFuncionario.Inserir(tela.Funcionario);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repoFuncionario.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionario(s)");
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
            return new ConfigurarStripFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionarios == null)
                tabelaFuncionarios = new FuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }
    }
}
