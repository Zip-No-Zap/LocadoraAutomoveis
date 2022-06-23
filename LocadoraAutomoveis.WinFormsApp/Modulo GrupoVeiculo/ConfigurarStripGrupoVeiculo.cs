using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_GrupoVeiculo
{
    public class ConfigurarStripGrupoVeiculo : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "cadastro de grupo de Veiculo";

        public override string TooltipInserir => "inserir novo grupo de Veiculo";

        public override string TooltipEditar => "editar grupo de Veiculo selecionado";

        public override string TooltipExcluir => "excluir grupo de Veiculo selecionado";
    }
}
