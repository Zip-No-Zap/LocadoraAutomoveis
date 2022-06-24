using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Cliente
{
    public class ConfiguracaoStripCliente : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro { get => "Cadastro Cliente"; }

        public override string TooltipEditar { get => "editar cliente selecionado"; }

        public override string TooltipExcluir { get => "excluir cliente selecionado"; }
    }
}
