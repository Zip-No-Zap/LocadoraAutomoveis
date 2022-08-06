using LocadoraAutomoveis.WinFormsApp.Compartilhado;


namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    public class ConfigurarStripLocacao : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de Locação";

        public override string TooltipInserir => "inserir locação";

        public override string TooltipEditar => "editar locação selecionada";

        public override string TooltipExcluir => "excluir locação selecionada";

        public override string TooltipDevolucao => "registrar devolução";

        public override string TooltipSeparar => "agrupar abertas/fechadas";

        public override bool DevolucaoHabilitado => true;

        public  override bool SepararHabilitado => true;

    }
}
