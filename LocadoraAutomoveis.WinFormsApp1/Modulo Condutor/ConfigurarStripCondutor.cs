using LocadoraAutomoveis.WinFormsApp.Compartilhado;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Condutor
{
    public class ConfigurarStripCondutor : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de Condutor";

        public override string TooltipInserir => "inserir novo condutor";

        public override string TooltipEditar => "editar condutor selecionado";

        public override string TooltipExcluir => "excluir condutor selecionado";
    }
}
