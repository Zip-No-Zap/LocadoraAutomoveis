using LocadoraAutomoveis.WinFormsApp.Compartilhado;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public class ConfiguracaoStripPlano : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de Planos";

        public override string TooltipInserir => "inserir plano";

        public override string TooltipEditar => "editar plano selecionado";

        public override string TooltipExcluir => "excluir plano selecionado";
    }
}
