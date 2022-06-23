using LocadoraAutomoveis.WinFormsApp.Compartilhado;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_Taxa
{
    public class ConfiguracaoStripTaxa : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir => "inserir taxa";

        public override string TooltipEditar => "editar taxa selecionada";

        public override string TooltipExcluir => "excluir taxa selecionada";
    }
}
