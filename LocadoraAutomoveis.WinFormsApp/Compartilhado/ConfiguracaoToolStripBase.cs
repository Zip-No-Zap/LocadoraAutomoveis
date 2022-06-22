using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public class ConfiguracaoToolStripBase
    {
        public string TipoCadastro { get; }

        public string TooltipInserir { get; }

        public string TooltipEditar { get; }

        public string TooltipExcluir { get; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }
    }
}
