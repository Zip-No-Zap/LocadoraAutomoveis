using LocadoraAutomoveis.WinFormsApp.Compartilhado;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public class ConfiguracaoStripVeiculo : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de veiculo";

        public override string TooltipInserir => "inserir veiculo";

        public override string TooltipEditar => "editar veiculo selecionado";

        public override string TooltipExcluir => "excluir veiculo selecionado";
    }
}
