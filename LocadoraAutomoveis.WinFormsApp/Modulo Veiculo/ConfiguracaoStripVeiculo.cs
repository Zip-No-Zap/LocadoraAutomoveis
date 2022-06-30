using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    public class ConfiguracaoStripVeiculo : ConfiguracaoToolStripBase
    {
        public override string TipoCadastro => "Cadastro de veiculo";

        public override string TooltipInserir => "inserir veiculo";

        public override string TooltipEditar => "editar veiculo selecionado";

        public override string TooltipExcluir => "excluir veiculo selecionado";
    {
    }
}
