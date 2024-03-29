﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace LocadoraAutomoveis.WinFormsApp.Compartilhado
{
    public class ConfiguracaoToolStripBase
    {
        public virtual string TipoCadastro { get => "Registro"; }
  
        public virtual string TooltipInserir { get => "inserir registro"; }
     
        public virtual string TooltipEditar { get => "editar registro selecionado"; }

        public virtual string TooltipExcluir { get => "excluir registro selecionado"; }

        public virtual string TooltipDevolucao { get => ""; }

        public virtual string TooltipSeparar { get => ""; }

        public virtual string TooltipExcluirFechadas { get => ""; }


        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool DevolucaoHabilitado { get { return false; } }

        public virtual bool SepararHabilitado { get { return false; } }

        public virtual bool ExcluirFechadasHabilitado { get { return false; } }
    }
}
