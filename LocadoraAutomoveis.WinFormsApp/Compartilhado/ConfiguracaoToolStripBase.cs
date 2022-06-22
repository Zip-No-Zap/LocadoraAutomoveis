using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public class ConfiguracaoToolStripBase
    {
        string TipoCadastro { get; }
       
        string TooltipInserir { get; }
       
        string TooltipEditar { get; }
       
        string TooltipExcluir { get; }

        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }
    }
}
