using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public class ConfiguracaoToolStripBase
    {
        public string TipoCadastro { get => "Cadastro"; }

        public string TooltipInserir { get => "inserir registro"; }

        public string TooltipEditar { get => "editar registro selecionado"; }

        public string TooltipExcluir { get => "excluir registro selecionado"; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }
    }
}
