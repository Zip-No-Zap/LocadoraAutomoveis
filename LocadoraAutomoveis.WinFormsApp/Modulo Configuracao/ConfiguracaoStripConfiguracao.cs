
using LocadoraAutomoveis.WinFormsApp.Compartilhado;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public class ConfiguracaoStripConfiguracao : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Configurações";
        public override string TooltipInserir => "";
        public override string TooltipEditar => "";
        public override string TooltipExcluir => "";
        public override string TooltipDevolucao => "";
        public override bool InserirHabilitado { get { return false; } }
        public override bool EditarHabilitado { get { return false; } }
        public override bool ExcluirHabilitado { get { return false; } }
    }
}
