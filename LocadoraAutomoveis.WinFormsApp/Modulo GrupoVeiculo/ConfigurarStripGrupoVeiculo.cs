using LocadoraAutomoveis.WinFormsApp.Compartilhado;


namespace LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo
{
    public class ConfigurarStripGrupoVeiculo : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de Grupo de Veículo";

        public override string TooltipInserir => "inserir novo grupo de veículo";

        public override string TooltipEditar => "editar grupo de veículo selecionado";

        public override string TooltipExcluir => "excluir grupo de veiculo selecionado";
    }
}
