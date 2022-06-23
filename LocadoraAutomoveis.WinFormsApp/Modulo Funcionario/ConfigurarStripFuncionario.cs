
using LocadoraAutomoveis.WinFormsApp.Compartilhado;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_Funcionario
{
    public class ConfigurarStripFuncionario : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro  => "cadastro de funcionário";

        public override string TooltipInserir => "inserir novo funcionário";

        public override string TooltipEditar => "editar funcionário selecionado";

        public override string TooltipExcluir => "excluir funcionário selecionado";
    }
}
