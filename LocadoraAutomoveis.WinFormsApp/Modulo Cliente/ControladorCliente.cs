using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using System.Collections.Generic;

using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Cliente
{
    public class ControladorCliente : ControladorBase
    {
        RepositorioClienteEmBancoDados repoCliente;
        ClienteControl tabelaClientes;

        public ControladorCliente()
        {
            repoCliente = new();
        }

        public override void Inserir()
        {
            TelaCadastroCliente tela = new();
            tela.Cliente = new();

            tela.GravarRegistro = repoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            Cliente Selecionado = ObtemClienteSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCliente tela = new();

            tela.Cliente = Selecionado;

            tela.GravarRegistro = repoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Excluir()
        {
            Cliente Selecionado = ObtemClienteSelecionado();

            if (Selecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repoCliente.Excluir(Selecionado);

                CarregarClientes();
            }
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfiguracaoStripCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaClientes == null)
                tabelaClientes = new ClienteControl();

            CarregarClientes();

            return tabelaClientes;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repoCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);

            FormPrincipal.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }

        private Cliente ObtemClienteSelecionado()
        {
            var numero = tabelaClientes.ObtemNumerClienteSelecionado();

            return repoCliente.SelecionarPorId(numero);
        }
    }
}
